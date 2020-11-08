using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AssignBubbleScript : MonoBehaviour
{
    [SerializeField] GameObject[] interactables;
    void Start()
    {
        interactables = GameObject.FindGameObjectsWithTag("InteractableBubble") ;
        for (int i = 0; i < interactables.Length; i++)
        {

            interactables[i].AddComponent<BubbleController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
