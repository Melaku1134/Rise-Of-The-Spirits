using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
// Update is called once per frame

public class QuitGame : MonoBehaviour
{
    // Call this method to quit the game
    public void Quit()
    {
        // Logs a message when quitting in the editor
        Debug.Log("Quitting game...");

        // If running in the Unity editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If running as a built application
        Application.Quit();
#endif
    }
}


