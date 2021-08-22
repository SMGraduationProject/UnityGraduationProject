using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FakeTerminal : MonoBehaviour
{
    //public int custom_FunctionsNumber = 0;
    [SerializeField]
    public UnityEvent[] custom_Functions;
    
    [Space][Space]

    public List<CustomText> custom_Inputs;

    [Space][Space]

    public List<CustomText> custom_Texts;

    [Space][Space]

    public bool admin_RequestLogin;
    public bool admin_RequestQuiz1;
    public string admin_Password;
    public string quiz1_Answer;
    public string quiz2_Answer;
    public string quiz3_Answer;
    public bool admin_AutoLogOut;

    [Space]

    public bool text_ForceCapsLock;

    [Space]

    public KeyCode key_TurnOn;
    public bool key_UseKeyToShutDown;
    public KeyCode key_ShutDown;

    [Space]

    public Vector3 terminal_PoVOffset;
    public float terminal_ActivationTransitionSpeed;
    public float terminal_ShutDownTransitionSpeed;

    [Space]

    //public CharacterController player_CharController;
    public GameObject g;
    public Camera player_Camera;

    [Space]

    public float terminal_MaxActivationDistance;

    [Space]

    public string[] inputs_Help;
    public string[] inputs_Clear;
    public string[] inputs_Shutdown;
    public string[] inputs_Answer;

    //----//

    ///INSERT HERE OTHER STRING[] INPUTS

        //  EXAMPLE:

        //  [...]
        //
        //   public string[] inputs_Example;
        //
        //   [...]

    //----//

    [Space]

    public string[] text_Intro;
    public string[] text_Error;
    public string[] text_Help;
    public string[] text_AccessDenied;
    public string[] text_AccessGranted;
    public string[] text_ShutDownKey;
    public string[] text_ShutDownCommand;
    public string[] text_quiz1;
    public string[] text_quiz2;
    public string[] text_quiz3;
    public string[] text_Retry;

    //  INSERT HERE OTHER TEXTS

    //  If you want to add a new function,
    //  you can create a new string[] array and change text through the editor...

    //  EXAMPLE:

    //  [...]
    //
    //  public string[] text_ShutDownCommand;
    //
    //  [...]

    //  or manually add strings in your custom function.

    //  EXAMPLE:

    //  [...]
    //
    //  void CustomFunction()
    //  {
    //
    //      [...]
    //
    //      AddLineToList("EXAMPLE LINE 1");
    //      AddLineToList("EXAMPLE LINE 2");
    //
    //      [...]
    //
    //  }
    //
    //  [...]

    //----//

    [Space]

    public float intro_TimeToPrintLine;
    //  It's the time that passes before printing the next intro string.
    public int text_MaxStringsOnScreen;
    //   You have to manually set up the max number of visible lines...
    public int text_MaxCharsInString;
    //   ... and the max number of chars per line to keep the terminal text inside the "fake" screen.
    [Space]

    public char cursor_Char;
    //  Choose your favorite cursor char. Default: █
    public float cursor_BlinkingTime;
    //  Choose cursor blinking time.

    //----//

    private List<string> outputText = new List<string>();
    //  Basically, this script uses a list of strings. Every frame last string in the list is updated with your input chars.
    //  When you press Enter a new string is added to list and, if you have reached lines cap (text_MaxStringsOnScreen), the oldest line is removed (FIFO: first in, first out).

    private Text screen;

    private int actualLine;
    //  This value goes from 0 to text_MaxStringsOnScreen - 1 (it's the list index).
    private int fakeLine;
    //  Just esthetics. It's a sequential number shown in each line.
    private string lineIntro;
    private string text_quiz_test;
    private string quizIntro;
    //  This string contains the first chars of every line.
    private string originalPassword;
    private string lineIntro2 = "First, you need to login into this system to solve some quiz and open the door.\n" +
                        "The password is the right answer of this questions below.\n" +
                        "What is the result of multiplying the number of legs of an octopus\n" +
                        "by the number of legs of a squid by the number of horns of a giraffe?\n";
    private string text_unlocked = "You solved all quiz well!\n" +
        "Now the Door is opened. Shut Down this System and Go To Get The Key!\n";

    private bool terminalIsRunning;
    private bool terminalStarting;
    private bool terminalIsIdling;
    private bool cursorVisible;
    //  Variables used to control the terminal state.
    private bool lockCamera;
    private bool oldPositionSaved;
    private bool logged;
    private bool quiz1_unlocked;

    private int quizNum = 0;

    private Vector3 oldPlayerPoVPosition;
    
    private Quaternion oldPlayerPoVRotation;
    //  The player's camera has to return in its original position when the terminal is shut down.

    void Start()
    {

        if(admin_Password == "") // Default admin_Password is 12345.
        {
            admin_Password = "400"; // It's also the combination on my luggage... https://www.youtube.com/watch?v=a6iW-8xPw3k
        }
        
        if(("" + cursor_Char) == " ")
        {
            cursor_Char = '█';
        }

        if (quiz1_Answer == "") // Default admin_Password is 12345.
        {
            quiz1_Answer = "50000"; // It's also the combination on my luggage... https://www.youtube.com/watch?v=a6iW-8xPw3k
        }

        if (quiz2_Answer == "") // Default admin_Password is 12345.
        {
            quiz2_Answer = "60000"; // It's also the combination on my luggage... https://www.youtube.com/watch?v=a6iW-8xPw3k
        }

        if (quiz3_Answer == "") // Default admin_Password is 12345.
        {
            quiz3_Answer = "70000"; // It's also the combination on my luggage... https://www.youtube.com/watch?v=a6iW-8xPw3k
        }


        originalPassword = admin_Password;

        actualLine = 0;
        fakeLine = 0;

        cursorVisible = false;

        terminalIsIdling = true;
        terminalStarting = false;
        terminalIsRunning = false;

        logged = false;
        oldPositionSaved = false;
        quiz1_unlocked = false;

        lockCamera = false;

        screen = this.GetComponent<Text>();

        terminal_PoVOffset = new Vector3(terminal_PoVOffset.x, terminal_PoVOffset.y, -terminal_PoVOffset.z);

        StartCoroutine("TerminalIdlingCursor");
    }

    void LateUpdate()
    {
        if(admin_RequestLogin)
        {
            key_UseKeyToShutDown = true;
        }

        if(Input.GetKeyDown(key_TurnOn) && (this.transform.position - player_Camera.transform.position).magnitude < terminal_MaxActivationDistance && terminalIsIdling)
        {
            StopCoroutine("TerminalIdlingCursor");
            StopCoroutine("ExitTerminalTransition");
            lockCamera = true;

            terminalIsIdling = false;
            terminalStarting = true;
            terminalIsRunning = true;

            StartCoroutine("TerminalStart");
            StartCoroutine("TerminalRunningCursor");
        }

        if(lockCamera)
        {
            FirstPersonAIO player_CharController = g.GetComponent<FirstPersonAIO>();


            if (player_CharController != null)
            {
                player_CharController.playerCanMove = false;
            }

            if(!oldPositionSaved)
            {
                oldPlayerPoVPosition = player_Camera.transform.position;
                oldPlayerPoVRotation = player_Camera.transform.rotation;

                oldPositionSaved = true;
            }

            player_Camera.transform.position = Vector3.Lerp(player_Camera.transform.position, this.transform.position + terminal_PoVOffset, terminal_ActivationTransitionSpeed * Time.deltaTime);
            player_Camera.transform.rotation = Quaternion.Lerp(player_Camera.transform.rotation, this.transform.rotation, terminal_ActivationTransitionSpeed * Time.deltaTime);

            if(!terminalStarting && terminalIsRunning)
            {
                TerminalInput();
            }

            if(text_ForceCapsLock)
                {
                    admin_Password = admin_Password.ToUpper();
                }
                else
                {
                    admin_Password = originalPassword;
                }
            }

        if((key_UseKeyToShutDown || !logged) && Input.GetKeyDown(key_ShutDown) && terminalIsRunning)
        {
            ShutdownTerminal();
        }
    }

    //----//

    void ExitTerminalTransition()
    {
        lockCamera = false;

        FirstPersonAIO player_CharController = g.GetComponent<FirstPersonAIO>();

        // while(player_Camera.transform.position != oldPlayerPoVPosition)
        // {
        player_Camera.transform.position = Vector3.Lerp(player_Camera.transform.position, oldPlayerPoVPosition, terminal_ShutDownTransitionSpeed * Time.deltaTime);
            player_Camera.transform.rotation = Quaternion.Lerp(player_Camera.transform.rotation, oldPlayerPoVRotation, terminal_ShutDownTransitionSpeed * Time.deltaTime);

            //yield return new WaitForEndOfFrame();
       // }

        player_Camera.transform.position = oldPlayerPoVPosition;
        player_Camera.transform.rotation = oldPlayerPoVRotation;

        oldPositionSaved = false;

        if(player_CharController != null)
        {
            player_CharController.playerCanMove = true;
        }
    }

    //----//

    private void ShutdownTerminal()
    {
        StopAllCoroutines();

        terminalIsIdling = true;
        terminalStarting = false;
        terminalIsRunning = false;

        Cursor.lockState = CursorLockMode.Locked;

        if(admin_AutoLogOut)
        {
            logged = false;
        }

        StartCoroutine("TerminalIdlingCursor");

        StartCoroutine("ExitTerminalTransition");
    }

    //----//

    private void TerminalInput()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b') //   Has backspace/delete been pressed?
            {
                if (outputText[actualLine].Length > lineIntro.Length)
                {
                    if(outputText[actualLine].Contains("" + cursor_Char) && outputText[actualLine].Length > lineIntro.Length + 1)
                    {
                        outputText[actualLine] = outputText[actualLine].Substring(0, outputText[actualLine].Length - 2) + cursor_Char;
                    }
                    else if(!outputText[actualLine].Contains("" + cursor_Char))
                    {
                        outputText[actualLine] = outputText[actualLine].Substring(0, outputText[actualLine].Length - 1);
                    }
                }
            }
            else if ((c == '\n') || (c == '\r')) // Has enter/return been pressed?
            {
                if(outputText[actualLine].Contains("" + cursor_Char))
                {
                    string temp = "";
                    foreach(char letter in outputText[actualLine])
                    {
                        if(letter != cursor_Char)
                        temp += letter;
                    }
                    outputText[actualLine] = temp;
                }

                if(!logged && admin_RequestLogin)
                {
                    if(text_ForceCapsLock)
                    {
                        outputText[actualLine] = outputText[actualLine].ToUpper();
                    }

                    if (outputText[actualLine].Replace("" + cursor_Char, "").Substring(lineIntro.Length) == admin_Password)
                    {
                        logged = true;
                        PrintAccessGranted();
                        quizNum = 1;
                    }
                    else
                    {
                        PrintAccessNegate();
                    }
                }
                else
                {
                    bool printError = true;

                    if (outputText[actualLine].Replace("" + cursor_Char, "").Length > lineIntro.Length)
                    {
                        //----//

                        // ADD HERE NEW CUSTOM COMMANDS

                            // EXAMPLE:

                            // [...]
                            //
                            //  foreach(string input_Example in inputs_Example)
                            //  {
                            //      if(outputText[actualLine].Length >= lineIntro.Length)
                            //      {
                            //          if(outputText[actualLine].Replace("" + cursor_Char, "").Substring(lineIntro.Length) == input_Example)
                            //          {
                            //              printError = false;
                            //
                            //              ADD CUSTOM ACTION TO EXECUTE WHEN PLAYER USES THIS COMMAND
                            //
                            //          }
                            //      }
                            //  }
                            //
                            //  [...]

                        //----//

                        for(int custom_InputsIndex = 0; custom_InputsIndex < custom_Inputs.Count; custom_InputsIndex++)
                        {
                            foreach(string input_Text in custom_Inputs[custom_InputsIndex].text_Input)
                            {
                                if(outputText[actualLine].Length >= lineIntro.Length)
                                {
                                    if(outputText[actualLine].Replace("" + cursor_Char, "").Substring(lineIntro.Length) == input_Text)
                                    {
                                        printError = false;
                                        PrintCustomText(custom_InputsIndex);
                        
                                        custom_Functions[custom_InputsIndex].Invoke();
                                    }
                                }
                            }
                        }

                        //----//

                        foreach(string input_Help in inputs_Help)
                        {
                            if(outputText[actualLine].Length >= lineIntro.Length)
                            {
                                if(outputText[actualLine].Replace("" + cursor_Char, "").Substring(lineIntro.Length) == input_Help)
                                {
                                    printError = false;
                                    PrintHelp();
                                }
                            }
                        }

                        //----//

                        foreach(string input_Clear in inputs_Clear)
                        {
                            if(outputText[actualLine].Length >= lineIntro.Length)
                            {
                                if(outputText[actualLine].Replace("" + cursor_Char, "").Substring(lineIntro.Length) == input_Clear)
                                {
                                    printError = false;
                                    outputText = new List<string>();
                                    outputText.Add("");

                                    actualLine = 0;
                                    fakeLine = -1;
                                }
                            }
                        }

                        foreach(string input_Shutdown in inputs_Shutdown)
                        {
                            if(outputText[actualLine].Length >= lineIntro.Length)
                            {
                                if(!key_UseKeyToShutDown && outputText[actualLine].Replace("" + cursor_Char, "").Substring(lineIntro.Length) == input_Shutdown)
                                {
                                    printError = false;
                                    ShutdownTerminal();
                                }
                            }
                        }
                        PrintError(printError);
                    }
                }

                if(!logged && admin_RequestLogin)
                {
                    lineIntro = "Insert password: ";
                    fakeLine = -1;

                    AddLineToList(lineIntro2);
                    AddLineToList(lineIntro);
                }
                else if(logged && (quizNum ==1))
                {
                    text_quiz_test = "What???\n";
                    quizIntro = "Insert answer: ";

                    AddLineToList(text_quiz_test);
                    AddLineToList(quizIntro);

                    if (outputText[actualLine].Length >= quizIntro.Length)
                    {
                        if (outputText[actualLine].Replace("" + cursor_Char, "").Substring(quizIntro.Length) == quiz1_Answer)
                        {
                            PrintQuiz2();
                        }
                        else if (outputText[actualLine].Replace("" + cursor_Char, "").Substring(quizIntro.Length) != quiz1_Answer)
                        {
                            PrintRetry();
                        }
                    }

                }
                else
                {
                    fakeLine++;
                    lineIntro = "" + fakeLine + ".  ";
                    AddLineToList(lineIntro);
                }

            }
            else
            {
                if(outputText[actualLine].Contains("" + cursor_Char))
                {
                    string temp = "";
                    foreach(char letter in outputText[actualLine])
                    {
                        if(letter != cursor_Char)
                        temp += letter;
                    }

                    if(outputText[actualLine].Length < text_MaxCharsInString)
                    {
                        outputText[actualLine] = temp + c + cursor_Char;
                    }
                }
                else
                {
                    if(outputText[actualLine].Length < text_MaxCharsInString)
                    {
                        outputText[actualLine] += c;
                    }
                }
            }
        }
        screen.text = GenerateTextFromList(outputText);
    }

    //----//

    IEnumerator TerminalStart()
    {
        outputText = new List<string>();
        fakeLine = 0;

        foreach(string line in text_Intro)
        {
            outputText.Add(line);
            actualLine++;
            screen.text = GenerateTextFromList(outputText);
            yield return new WaitForSeconds(intro_TimeToPrintLine);
        }

        AddLineToList("");

            if (!logged && admin_RequestLogin)
            {
                lineIntro = "Insert password: ";

            AddLineToList(lineIntro2);
            AddLineToList(lineIntro);
        }
        else if (logged && admin_RequestLogin)
            {
                PrintAccessGranted();
                lineIntro = "" + fakeLine + ".  ";
            }
        else if(!admin_RequestLogin)
        {
            lineIntro = "" + fakeLine + ".  ";
        }

        //AddLineToList(lineIntro2);
        //AddLineToList(lineIntro);

        screen.text = GenerateTextFromList(outputText);

        terminalStarting = false;
    }

    IEnumerator TerminalIdlingCursor()
    {   
        while(terminalIsIdling)
        {
            outputText = new List<string>();
            if(!terminalStarting)
            {
                if(!cursorVisible)
                {
                    outputText.Add("" + cursor_Char);
                    cursorVisible = true;
                }
                else
                {  
                    cursorVisible = false;
                }
            }

            screen.text = GenerateTextFromList(outputText);

            yield return new WaitForSeconds(cursor_BlinkingTime);
        }
    }

    IEnumerator TerminalRunningCursor()
    {
        while(terminalIsRunning)
        {
            if(!terminalStarting)
            {
                if(!cursorVisible)
                {
                    bool cursorAlreadyExist = false;

                    foreach(char letter in outputText[outputText.Count - 1])
                    {
                        if(letter == cursor_Char)
                        {
                            cursorAlreadyExist = true;
                        }
                    }

                    if(!cursorAlreadyExist)
                    {
                        outputText[outputText.Count - 1] += cursor_Char;
                    }
                    cursorVisible = true;
                }
                else
                {
                    string temp = "";
                    foreach(char letter in outputText[outputText.Count - 1])
                    {
                        if(letter != cursor_Char)
                        {
                            temp += letter;
                        }
                    }

                    outputText[outputText.Count - 1] = temp;
                    cursorVisible = false;
                }
            }
            yield return new WaitForSeconds(cursor_BlinkingTime);
        }

    }

    //----//

    private void UpdateLineIndex()
    {
        if(actualLine + 1 <= text_MaxStringsOnScreen)
        {
            actualLine++;
        }
        ScrollText();
    }

    //----//

    private void PrintError(bool print)
    {
        if(print)
        {
            foreach(string line in text_Error)
            {
                AddLineToList(line);
            }
        }
    }

    private void PrintHelp()
    {
        foreach(string line in text_Help)
        {
            AddLineToList(line);
        }

        if(key_UseKeyToShutDown)
        {
            foreach(string line in text_ShutDownKey)
            {
                AddLineToList(line);
            }
        }
        else
        {
            foreach(string line in text_ShutDownCommand)
            {
                AddLineToList(line);
            }
        }
    }

    private void PrintQuiz1()
    {
        foreach(string line in text_quiz1)
        {
            AddLineToList(line);
        }
    }

    private void PrintQuiz2()
    {
        foreach (string line in text_quiz2)
        {
            AddLineToList(line);
        }
    }

    private void PrintQuiz3()
    {
        foreach (string line in text_quiz3)
        {
            AddLineToList(line);
        }
    }

 /*   private void PrintUnlocked()
    {
        foreach(string line in text_unlocked)
        {
            AddLineToList(line);
        }
    }
 */
    private void PrintAccessGranted()
    {
        foreach(string line in text_AccessGranted)
        {
            AddLineToList(line);
        }
    }

    private void PrintAccessNegate()
    {
        foreach(string line in text_AccessDenied)
        {
            AddLineToList(line);
        }
    }

    private void PrintCustomText(int custom_Index)
    {
        foreach(string line in custom_Texts[custom_Index].text_Input)
        {
            AddLineToList(line);
        }
    }

    private void PrintRetry()
    {
        foreach (string line in text_Retry)
        {
            AddLineToList(line);
        }
    }
    
    //----//

    private void AddLineToList(string newLine)
    {
        outputText.Add(newLine);
        UpdateLineIndex();
    }

    private void ScrollText()
    {
        if(outputText.Count > text_MaxStringsOnScreen)
        {
            List<string> temp = new List<string>();

            for(int i = 1; i < text_MaxStringsOnScreen + 1; i++)
            {
                temp.Add(outputText[i]);
            }

            outputText = temp;

            actualLine--;
        }
    }

    private string GenerateTextFromList(List<string> lines)
    {
        actualLine = -1;

        string textToPrint = "";

        foreach(string line in lines)
        {
            actualLine++;
            if(text_ForceCapsLock)
            {
                textToPrint += (line.ToUpper() + "\n");
            }
            else
            {
                textToPrint += (line + "\n");
            }
        }

        return textToPrint;
    }

    [System.Serializable] 
    public class CustomText
    {
        public string[] text_Input;
    }
}
