using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private List<Transform> patrolPoints;
    [SerializeField]
    private float tresholdToPatrolPoint=1.0f;
    private Transform patrolActualDestination;
    private NavMeshAgent agent;
    public bool isChasing { get; set; }
    public bool isPatrolling{ get; set; }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolActualDestination = patrolPoints[Random.Range(0,patrolPoints.Count)];
    }

    void Update()
    {
        if (isChasing)
        {
            agent.destination = player.transform.position;
            agent.isStopped = false;
        }
        else
        {
            if(!isPatrolling){
                agent.isStopped = true;
            }
            else{
                if((transform.position - patrolActualDestination.transform.position).magnitude<tresholdToPatrolPoint)
                {
                    patrolActualDestination = patrolPoints[Random.Range(0,patrolPoints.Count)];
                }
                agent.destination = patrolActualDestination.transform.position;
                agent.isStopped = false;
            }
            
        }
    }


    void MoveToOnClickedPoint()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
    }
}
