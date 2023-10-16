using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float DetectRadius;
    public float DetectAngle;
    private NavMeshAgent navMeshAgent;
    public float enemiesLengthMin;
    public int enemiesLengthMinIndex;
    public GameObject Target;
    public EnemyController[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        navMeshAgent.isStopped = true;
        Detect();
    }

    public void Detect()
    {
        enemies = FindObjectsOfType<EnemyController>();
        //Debug.Log(enemies.Length+gameObject.name);
        enemiesLengthMin = DetectRadius + 1;
        for (int i = 0; i < enemies.Length; i++)
        {
            if(Vector3.Distance(transform.position,enemies[i].gameObject.transform.position)< enemiesLengthMin)
            {
                if(Vector3.Distance(transform.position, enemies[i].gameObject.transform.position) != 0)
                {
                    enemiesLengthMin = Vector3.Distance(transform.position, enemies[i].gameObject.transform.position);
                    //Debug.Log(enemiesLengthMin);
                    enemiesLengthMinIndex = i;
                }
                else
                {
                    Debug.LogWarning("asdf");
                }  
                
            }

        }
        Target= enemies[enemiesLengthMinIndex].gameObject;
        navMeshAgent.SetDestination(enemies[enemiesLengthMinIndex].gameObject.transform.position);
        if (DetectRadius >= enemiesLengthMin)
        {
            Move();
        }
        //Debug.Log(Vector3.Distance(transform.position, enemies[enemiesLengthMinIndex].gameObject.transform.position)+gameObject.name);
    }

    private void Move()
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speed;
    }
}
