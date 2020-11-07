using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grab : MonoBehaviour
{
    public Image newspiece;
    public GameObject canvas;
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
            this.gameObject.SetActive(false);            
        }
    }
}
