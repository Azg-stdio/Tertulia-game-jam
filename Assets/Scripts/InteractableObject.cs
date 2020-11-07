using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class InteractableObject : MonoBehaviour
{
    bool interaction = false;
    bool hiding=false;   
    Outline outline;
    public enum action{Hide, Grab, Teleport};
    public action actions;
    public Transform teleportpos;
    void Start()
    {
        outline=GetComponent<Outline>();
        outline.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (hiding){
                UnHide();
            }
            else if (interaction){
                DoAction();
                Debug.Log("interaction");
                interaction=false;
            }                
        }
    }
        
    void OnTriggerEnter(Collider player) {
        if (player.tag=="Player"){
            //Show UI Space button
            interaction=true;
            outline.enabled=true;
        }
    }

    void OnTriggerExit(Collider player) {
        if (player.tag=="Player"){
            //Hide UI Space button
            interaction=false;
            outline.enabled=false;
        }
    }

    void DoAction(){
        if (actions == action.Hide){
            //Do animation
            //Change sprite
            //Hide from monster
            hiding=true;
            Debug.Log("Hiding");            
        }
        else if (actions == action.Grab){
            //Do zoom and pause
            //Fill door
        }
        else if (actions == action.Teleport){
            GameObject.FindGameObjectWithTag("Player").transform.position=teleportpos.position;
            Debug.Log("Teleport");
        }
    }

    void UnHide(){
        //Stop animation
        //Change sprite
        //Unhide from monster
        hiding=false;
        Debug.Log("Unhiding");
    }    
}
