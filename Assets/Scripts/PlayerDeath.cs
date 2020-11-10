using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public Image img;
    public Transform initialpos, finalpos;
    public Transform bosspos;
    public GameObject boss;
    public AudioSource death;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("LoadScreen");
        }
    }

    void OnTriggerEnter(Collider enemy) {
        if (enemy.tag=="Enemy"){               
            death.Play();
            GetComponent<PlayerController>().StopMoving();
            StartCoroutine(FadeImage(false));
        }
        if (enemy.tag=="Door"){  
            GetComponent<PlayerController>().StopMoving();
            StartCoroutine(FadeImage(false));
            StartCoroutine(FinishGame());
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
            GetComponent<PlayerController>().StartMoving();            
            // loop over 1 second backwards
            for (float i = 2; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i/2);
                yield return null;
            }
            img.color = new Color(0, 0, 0, 0);            
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
            boss.transform.position=bosspos.position;
            yield return new WaitForSeconds(1.0f);
            StartCoroutine(FadeImage(true));
        }
    }

    IEnumerator FinishGame(){
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("LoadScreen");
    }
}
