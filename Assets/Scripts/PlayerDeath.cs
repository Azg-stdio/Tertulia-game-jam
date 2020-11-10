using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public Image img;
    public Transform initialpos, finalpos;
    public AudioSource death;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider enemy) {
        if (enemy.tag=="Enemy"){               
            death.Play();
            GetComponent<PlayerController>().StopMoving();
            StartCoroutine(FadeImage(false));
        }
    }

    public void TeleportToPos(Transform pos){
        transform.position=pos.position;        
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 2; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i/2);
                yield return null;
            }
            img.color = new Color(0, 0, 0, 0);
            GetComponent<PlayerController>().StartMoving();
        }
        
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 2; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i/2);
                yield return null;
            }
            img.color = new Color(0, 0, 0, 1);
            TeleportToPos(initialpos);
            yield return new WaitForSeconds(1.0f);
            StartCoroutine(FadeImage(true));
        }
    }
}
