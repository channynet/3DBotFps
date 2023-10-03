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
    private float enemiesLengthMin;
    private int enemiesLengthMinIndex;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Detect();
    }

    private void Detect()
    {
        EnemyController[] enemies = FindObjectsOfType<EnemyController>();
        
        for(int i = 0; i < enemies.Length; i++)
        {
            if(Vector3.Distance(transform.position,enemies[i].gameObject.transform.position)< enemiesLengthMin)
            {
                enemiesLengthMin = Vector3.Distance(transform.position, enemies[i].gameObject.transform.position);
                enemiesLengthMinIndex = i;
            }

        }
        navMeshAgent.SetDestination(enemies[enemiesLengthMinIndex].gameObject.transform.position);
    }

    private void Move()
    {

    }
}
