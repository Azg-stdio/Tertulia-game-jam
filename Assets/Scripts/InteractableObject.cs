using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class InteractableObject : MonoBehaviour
{
    bool interaction = false; 
    Outline outline;
    public enum action{Hide, Grab, Teleport};
    public action actions;
    void Start()
    {
        outline=GetComponent<Outline>();
        outline.enabled=false;
    }
        
    void OnTriggerEnter(Collider player) {
        if (player.tag=="Player"){
            //Show UI Space button
            ActivateScript();
            interaction=true;
            outline.enabled=true;
        }
    }

    void OnTriggerExit(Collider player) {
        if (player.tag=="Player"){
            //Hide UI Space button
            DeActivateScript();
            interaction=false;
            outline.enabled=false;
        }
    }

    void ActivateScript(){
        if (actions == action.Hide){
            GetComponent<Hide>().enabled=true;      
        }
        else if (actions == action.Grab){
            GetComponent<Grab>().enabled=true;  
        }
        else if (actions == action.Teleport){
            GetComponent<Teleport>().enabled=true; 
        }
    }

    void DeActivateScript(){
        if (actions == action.Hide){
            GetComponent<Hide>().enabled=true;      
        }
        else if (actions == action.Grab){
            GetComponent<Grab>().enabled=true;  
        }
        else if (actions == action.Teleport){
            GetComponent<Teleport>().enabled=true; 
        }
    }
}
