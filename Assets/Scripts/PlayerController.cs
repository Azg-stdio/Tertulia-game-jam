using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float runSpeed = 20.0f;
    private Rigidbody rb;
    private Vector3 direction;
    private bool isRunning = false;
    private bool isMoving = true;
    public GameObject canvas;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving){
            direction.x = Input.GetAxis("Horizontal");
            direction.z = Input.GetAxis("Vertical");
            direction.Normalize();
            isRunning =  Input.GetButton("Run");
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

    public void StartMoving(){
        isMoving=true;
    }

    public void StopMoving(){
        isMoving=false;
        rb.velocity=Vector3.zero;
    }
}
