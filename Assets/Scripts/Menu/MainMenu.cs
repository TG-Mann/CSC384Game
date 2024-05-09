using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject fade;

    private int tutorial;

    public void playGame(){
        fade.SetActive(true);
        animator.SetTrigger("Fade");
        tutorial = 1;
        StartCoroutine("loadGame");
    }

    public void quitGame(){
        //UnityEditor.EditorApplication.isPlaying = false; // remove in built game
        Application.Quit();
    }

    public void resumeGame(){
        if (File.Exists(Application.dataPath + "/save.txt")){
            fade.SetActive(true);
            animator.SetTrigger("Fade");
            tutorial = 0;
            StartCoroutine("loadGame");
        }
       
    }

    void OnDisable(){
        PlayerPrefs.SetInt("tutorial", tutorial);
        PlayerPrefs.Save();
    }

    IEnumerator loadGame(){
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Game");
    }


}
