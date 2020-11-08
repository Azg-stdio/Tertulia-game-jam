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
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        isRunning =  Input.GetButton("Run");
    }
    private void FixedUpdate()
    {
        if (!isRunning) { rb.velocity = direction * speed; }
        else { rb.velocity = direction * runSpeed; }
    }
}
