using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private NavMeshAgent agent;
    public bool isChasing { get; set; }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
            agent.isStopped = true;
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
