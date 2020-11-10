using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject musicController;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float detectionRange = 10.0f;
    [SerializeField]
    private float tresholdToPatrolPoint = 1.0f;
    [SerializeField]
    private List<Transform> patrolPoints;
    private Transform patrolActualDestination;
    //private Animator logicAnimator;
    private NavMeshAgent agent;
    private MusicHandler musicHandler;
    public bool isStarted { get; set; }
    public bool isChasing { get; set; }
    public bool isPatrolling { get; set; }
    public bool canSeePlayer { get; set; }
    private string currentState;

    private const string SLEEP = "EnemyIdleSleep";
    private const string MOVE = "EnemyFollow";
    private float timer = 0.0f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //logicAnimator = GetComponent<Animator>();
        patrolActualDestination = patrolPoints[Random.Range(0, patrolPoints.Count)];
        isStarted = false;
        ChangeAnimationState(SLEEP);
        musicHandler = musicController.GetComponent<MusicHandler>();
        canSeePlayer = true;
        ActivateMonster();
    }

    void Update()
    {
        if (isChasing)
        {
            Debug.Log("HPO:A");
            agent.destination = player.transform.position;
            agent.isStopped = false;
        }
        else
        {
            if (!isPatrolling)
            {
                agent.isStopped = true;
            }
            else
            {
                
                if ((transform.position - patrolActualDestination.transform.position).magnitude < tresholdToPatrolPoint)
                {
                    patrolActualDestination = patrolPoints[Random.Range(0, patrolPoints.Count)];
                }
                agent.destination = patrolActualDestination.transform.position;
                agent.isStopped = false;
            }
        }
        UpdateDetectionLogic();

    }

    void UpdateDetectionLogic()
    {
        if (isStarted)
        {
            if (canSeePlayer == false) {isPatrolling = true; isChasing = false;musicHandler.DeactivateRush();}//logicAnimator.SetBool("isPatrolling", true);logicAnimator.SetBool("isChasing", false);}
            else
            {
                Debug.Log((player.transform.position - transform.position).magnitude);
                if ((player.transform.position - transform.position).magnitude < detectionRange) {
                    isPatrolling = false; isChasing = true;
                    musicHandler.ActivateRush();}//logicAnimator.SetBool("isChasing", true);
                    //logicAnimator.SetBool("isPatrolling", false);}

                else {isPatrolling = true; isChasing = false;musicHandler.DeactivateRush();}//logicAnimator.SetBool("isPatrolling", true);logicAnimator.SetBool("isChasing", false);}
            }
        }
    }
    public void ActivateMonster(){
        isStarted = true;
        ChangeAnimationState(MOVE);
        UpdateDetectionLogic();
    }
        void ChangeAnimationState(string newState){
        if(currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
}
