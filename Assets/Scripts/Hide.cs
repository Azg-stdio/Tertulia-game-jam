using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject pj;
    public bool hiding;
    public GameObject poofcloud;
    void Start()
    {
        hiding=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")){            
            if(hiding){
                //move monster away
                pj.GetComponent<SpriteRenderer>().enabled=false;
                GameObject clone = Instantiate(poofcloud, pj.transform.position, transform.rotation);
                Destroy(clone, 1.0f);
                hiding=!hiding;
            }   
            else{
                pj.GetComponent<SpriteRenderer>().enabled=true;
                hiding=!hiding;
            }                    
        }
    }
}
