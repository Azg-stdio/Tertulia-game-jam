﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grab : MonoBehaviour
{
    public Image newspiece;
    public GameObject canvas;
    public GameObject piece;
    public GameObject bubblehandler;
    public GameObject door;
    public int pieces=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            newspiece.sprite=GetComponent<SpriteRenderer>().sprite;
            canvas.SetActive(true);
            piece.SetActive(true);
            bubblehandler.GetComponent<BubbleReducer>().ReduceBubble();
            this.gameObject.SetActive(false);
            pieces++;
            if(pieces>=6){
                ActivateDoor();
            }
        }        
    }

    public void ActivateDoor(){
        door.GetComponent<SphereCollider>().enabled=true;
    }
}
