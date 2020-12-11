using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public AudioSource basic, rush;
    void Start()
    {
        AudioListener.volume=1.0f;
        PlayMainMusic();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)){
            ActivateRush();
        }
        if (Input.GetKeyDown(KeyCode.V)){
            DeactivateRush();
        }
    }

    public void ActivateRush(){
        StartCoroutine(ChangeMusic(true));
    }

    public void DeactivateRush(){
        StartCoroutine(ChangeMusic(false));
    }

    public void PlayMainMusic(){
        basic.volume=1;
        basic.Play();
        rush.volume=0;
        rush.Play();        
    }

    IEnumerator ChangeMusic(bool activeRush)
    {
        if (activeRush){
            rush.mute=false;
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {                
                rush.volume=i;
                basic.volume=1-i;
                yield return null;
            }
            rush.volume=1;
            basic.volume=0;
        }
        else{
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                
                rush.volume=1-i;
                basic.volume=i;
                yield return null;
            }
            rush.volume=0;
            basic.volume=1;
        }
    }

    public void KillMusic(){
        StartCoroutine(StopMusic());
    }

    IEnumerator StopMusic(){
        for (float i = 1; i >= 0; i -= (Time.deltaTime*1.2f))
        {                
            AudioListener.volume=i;
            yield return null;
        }
    }
}
