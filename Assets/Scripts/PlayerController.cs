using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float runSpeed = 20.0f;

    [SerializeField] Animator animator;
    private string currentState;
    private Rigidbody rb;
    private Vector3 direction;
    private bool isRunning = false;
    private bool isMoving = true;
    public GameObject canvas;

    //Animation names
    const string WALK_FRONT = "HeroWalkFrontViewWander";
    const string WALK_BACK = "HeroWalkBackwards";
    const string STAND_FRONT = "HeroIdleWander";
    const string STAND_BACK = "HeroIdleStandBack";

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ChangeAnimationState(STAND_FRONT);
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving){
            direction.x = Input.GetAxis("Horizontal");
            direction.z = Input.GetAxis("Vertical");
            direction.Normalize();
            if(direction.z > 0.05f)ChangeAnimationState(WALK_BACK);
            else if(direction.z < -0.05f || direction.x != 0.0f)ChangeAnimationState(WALK_FRONT);
            else {
                ChangeAnimationState(STAND_FRONT);
                //ChangeAnimationState(STAND_BACK);
            }
            //isRunning =  Input.GetButton("Run");
        }   
        if (Input.GetKeyDown("space")){     
            if (canvas.activeSelf){
                canvas.SetActive(false);
            }
        }    
    }
    private void FixedUpdate()
    {
        if(isMoving){
            if (!isRunning) { rb.velocity = direction * speed; }
            else { rb.velocity = direction * runSpeed; }
        }        
    }

    void ChangeAnimationState(string newState){
        if(currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }

    public void StartMoving(){
        isMoving=true;
    }

    public void StopMoving(){
        isMoving=false;
        ChangeAnimationState(STAND_FRONT);
        rb.velocity=Vector3.zero;
    }
}
