using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    [SerializeField] private GameObject[] tutorialMessages;
    private int tutorialStep;

    [SerializeField] Player player;

    bool playerTutorial = false; // to enable / disable tutorial

    bool changeMessage = true;

    [SerializeField] GameObject tutorialWall;

    [SerializeField] GameObject signPost;

    [SerializeField] GameObject enemies;

    // Update is called once per frame
    void Update()
    {
        if (playerTutorial){

            if (changeMessage){
                for (int i = 0; i < tutorialMessages.Length; i++){
                    if (i == tutorialStep){
                        tutorialMessages[i].SetActive(true);
                    } else{
                        tutorialMessages[i].SetActive(false);
                    }
                }
            }
       

            if (tutorialStep == 0){
                if (player.getPLayerState() == "Walk"){
                    StartCoroutine(Wait());
                    tutorialStep++;
                    changeMessage = false;
                }
            } 
            if (tutorialStep == 1){
                if (player.getPLayerState() == "Jump"){
                    StartCoroutine(Wait());
                    tutorialStep++;
                    changeMessage = false;
                }
            } 
            if (tutorialStep == 2){
                if (player.getPLayerState() == "DoubleJump"){
                    StartCoroutine(Wait());
                    tutorialStep++;
                    changeMessage = false;
                }
            }
            if (tutorialStep == 3){
                if (player.getPLayerState() == "Block"){
                    StartCoroutine(Wait());
                    tutorialStep++;
                    changeMessage = false;
                }
            }
            if (tutorialStep == 4){
                if (player.getPLayerState() == "Roll"){
                    StartCoroutine(Wait());
                    tutorialStep++;
                    changeMessage = false;
                }
            }
            if (tutorialStep == 5){
                if (player.getPLayerState() == "Dash"){
                    StartCoroutine(Wait());
                    tutorialStep++;
                    changeMessage = false;
                }
            }
            if (tutorialStep == 6){
                if (player.getPLayerState() == "AttackOne" || player.getPLayerState() == "AttackTwo"){
                    StartCoroutine(Wait());
                    tutorialStep++;
                    changeMessage = false;
                }
            }
            if (tutorialStep == 7){
                if (player.getPLayerState() == "AttackAir"){
                    StartCoroutine(Wait());
                    tutorialStep++;
                    changeMessage = false;
                }
            }
            if (tutorialStep == 8){
                tutorialWall.SetActive(false);
                signPost.SetActive(true);
                if (player.transform.position.x > -10){
                    StartCoroutine(Wait());
                    tutorialStep++;
                    changeMessage = false;
                    startGame();
                }
            }
        } else{
            tutorialWall.SetActive(false);
            signPost.SetActive(true);
            if (player.transform.position.x > -10){
                startGame();
            }
        }
        

    }

    private void startGame(){
        enemies.SetActive(true);
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(.3f);
        changeMessage = true;
    }
}
