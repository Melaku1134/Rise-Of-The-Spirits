using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchButtons : MonoBehaviour
{

    public void LoadScene1()
    {

        SceneManager.LoadScene("Scene 1");
    }


    public void LoadScene2()
    {

        SceneManager.LoadScene("Scene 2");
    }


    public void LoadScene3()
    {

        SceneManager.LoadScene("Scene 3");
    }

    public void LoadScene4()
    {

        SceneManager.LoadScene("Scene 4");
    }


    public void QuitGame()
    {
       PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MainMenu");
    }
}