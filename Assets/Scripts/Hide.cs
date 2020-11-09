using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject pj;
    public GameObject meshtohide;
    public bool hiding;
    public GameObject poofcloud;
    private Vector3 lastpos;
    void Start()
    {
        hiding=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")){            
            if(!hiding){
                //move monster away
                pj.GetComponent<PlayerController>().StopMoving();   
                lastpos=pj.transform.position;
                pj.transform.position=transform.position;
                meshtohide.GetComponent<MeshRenderer>().enabled=false;
                GameObject clone = Instantiate(poofcloud, pj.transform.position, transform.rotation);
                Destroy(clone, 1.0f);
                hiding=!hiding;
            }   
            else{
                pj.GetComponent<PlayerController>().StartMoving();
                pj.transform.position=lastpos;
                hiding=!hiding;
                meshtohide.GetComponent<MeshRenderer>().enabled=true;
            }                    
        }
    }
}
