using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent m_enemy = null;
    [SerializeField] Transform[] m_tfWayPoints = null;
    int m_count = 0;

    void MoveToNextWayPoint()
    {
        if (m_enemy.velocity == Vector3.zero)
        {
            m_enemy.SetDestination(m_tfWayPoints[m_count++].position);
            if (m_count >= m_tfWayPoints.Length)
                m_count = 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        m_enemy = GetComponent<NavMeshAgent>();
        InvokeRepeating("MoveToNextWayPoint", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            //Debug.Log("test");
            SceneManager.LoadScene("GameOver2");
        }
    }

}
