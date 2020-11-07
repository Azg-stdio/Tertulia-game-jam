using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameCanvas : MonoBehaviour
{
    public GameObject canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateCanvas(){
        canvas.SetActive(true);
    }

    public void DeActiveCanvas(){
        canvas.SetActive(false);
    }
}
