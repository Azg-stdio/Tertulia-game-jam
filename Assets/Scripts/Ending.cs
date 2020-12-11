using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume=1.0f;
        StartCoroutine(WaitToFinish());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitToFinish(){
        yield return new WaitForSeconds(5.0f);
        bool continueCoroutine=true;
        float vol=1.0f;
        while(continueCoroutine) { 
            vol=vol-0.01f;
            AudioListener.volume=vol;
            if (vol<=0.0f){
                continueCoroutine=false;
            }
         yield return new WaitForSeconds(0.1f);
        }
        SceneManager.LoadScene("LoadScreen");
    }
}
