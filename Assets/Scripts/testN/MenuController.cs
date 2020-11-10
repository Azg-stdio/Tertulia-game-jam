using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Loader");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
