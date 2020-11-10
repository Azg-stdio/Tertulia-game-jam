using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject pj;
    public GameObject meshtohide;
    public GameObject EnemyRef;
    private EnemyController enemyController;
    public bool hiding;
    public GameObject poofcloud;
    private Vector3 lastpos;
    public AudioSource sfx;
    void Start()
    {
        hiding=false;
        enemyController = EnemyRef.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")){            
            if(!hiding){
                //move monster away
                enemyController.canSeePlayer = false;

                pj.GetComponent<PlayerController>().StopMoving();   
                lastpos=pj.transform.position;
                pj.transform.position=transform.position;
                meshtohide.GetComponent<MeshRenderer>().enabled=false;
                GameObject clone = Instantiate(poofcloud, pj.transform.position, transform.rotation);
                Destroy(clone, 1.0f);
                hiding=!hiding;
                sfx.Play();
            }   
            else{
                pj.GetComponent<PlayerController>().StartMoving();
                pj.transform.position=lastpos;
                hiding=!hiding;
                enemyController.canSeePlayer = true;
                meshtohide.GetComponent<MeshRenderer>().enabled=true;
            }                    
        }
    }
}
