using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame(){
        SceneManager.LoadScene("Game");
    }

    public void quitGame(){
        //UnityEditor.EditorApplication.isPlaying = false; // remove in built game
        Application.Quit();
    }
}
