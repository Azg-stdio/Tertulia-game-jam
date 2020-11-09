using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleReducer : MonoBehaviour
{
// Array to store all the GameObjects in the scene
    GameObject[] AllGameObjects;
    public float bubbleradius=4.0f;
    public GameObject bubble;
    public void ReduceBubble () {
        bubbleradius-=0.3f;    
        bubble.transform.localScale*=0.9f;  
        ChangeMaterials();
    }
    void ChangeMaterials(){
        AllGameObjects = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject go in AllGameObjects) {
            if (go.GetComponent<Renderer>()) {
                if(go.GetComponent<Renderer>().material.shader.name=="Shader Graphs/TransitionTest_3"){
                    go.GetComponent<Renderer>().sharedMaterial.SetFloat("_Radius", bubbleradius);
                }
                else if(go.GetComponent<Renderer>().material.shader.name=="Shader Graphs/TransitionTest_2"){
                    go.GetComponent<Renderer>().sharedMaterial.SetFloat("Vector1_72CC4653", bubbleradius);                
                    
                }
            }
        }
    }
}
