using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public GameObject mnuMain;
    public GameObject[] objsMain;
    public GameObject mnuControls;
    public GameObject[] objsControls; 
    public GameObject mnuCredits;
    public GameObject[] objsCredits;

    public void PlayGame()
    {
        Debug.Log("CLIIIIIIIIIIIICK");
        SceneManager.LoadScene("MainScene");
    }
    public void GoToMain()
    {
        ToggleMenus(mnuControls, objsControls, false);
        ToggleMenus(mnuCredits, objsCredits, false);
        ToggleMenus(mnuMain, objsMain, true);
    }
    public void GoToCredits()
    {
        ToggleMenus(mnuMain, objsMain, false);
        ToggleMenus(mnuControls, objsControls, false);
        ToggleMenus(mnuCredits, objsCredits, true);
    }
    public void GoToControls()
    {
        ToggleMenus(mnuMain, objsMain, false);
        ToggleMenus(mnuCredits, objsCredits, false);
        ToggleMenus(mnuControls, objsControls, true);
    }
    public void ToggleMenus(GameObject canvas, GameObject[] objs, bool toggle)
    {
        canvas.SetActive(toggle);
        foreach (GameObject obj in objs)
        {
            obj.SetActive(toggle);
        }
    }

}
