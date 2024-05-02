using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private int tutorial;

    public void playGame(){
        tutorial = 1;
        SceneManager.LoadScene("Game");
    }

    public void quitGame(){
        //UnityEditor.EditorApplication.isPlaying = false; // remove in built game
        Application.Quit();
    }

    public void resumeGame(){
        if (File.Exists(Application.dataPath + "/save.txt")){
            tutorial = 0;
            SceneManager.LoadScene("Game");
        }
       
    }

    void OnDisable(){
        PlayerPrefs.SetInt("tutorial", tutorial);
        PlayerPrefs.Save();
    }
}
