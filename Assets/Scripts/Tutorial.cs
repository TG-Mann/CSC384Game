using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private int tutorialStep;

    [SerializeField] Player player;

    int playerTutorial; // to enable / disable tutorial

    [SerializeField] GameObject tutorialWall;

    [SerializeField] GameObject signPost;

    [SerializeField] GameObject enemies;

    [SerializeField] private TextMeshProUGUI tutorialText;

    private string[] messages = new string[]{"Lets go through some controls before we begin","Try pressing 'A' or 'D' to move Left and Right", "Good Job",
        "Now press 'Space' to jump", "Nice One", "If you pess 'Space' twice you can double Jump, try double jumping.", "Excellent", "Try Holding 'Q'",  "Nice, This can be used to prevent you taking damage",
        "If you press 'CTRL' you will roll, You must be Walking at the same time", "Well Done", "Press 'Shift' to dash", "Watch out, this has a cooldown", "Now lets press the right or left mouse button to attack",
        "Finally lets perfrom an air attack", "Perfrom a double jump and then attack", "Brilliant, take a note of special items throughout the game these will give you increases abilities wehn activatyed usig '1', '2' or '3'. Now lets begin..."};

    private int sentence = 0;
    private bool endSentence = false;

    void Start(){

        if (playerTutorial == 1){
            
            tutorialText.text = "";
            StartCoroutine("Wait");
       
        } else{
            tutorialWall.SetActive(false);
            signPost.SetActive(true);
            if (player.transform.position.x > -10){
                startEnemies();
            }
        }
    }



    void Update()
    {
        print(endSentence);
        print(sentence);
        if (playerTutorial == 1 && endSentence){
            if (sentence == 0 || sentence == 2 || sentence == 4 || sentence == 6 || sentence == 8 || sentence == 10 || sentence == 12 || sentence == 14){
                StartCoroutine("betweenSentence"); 
                endSentence = false;
            } else if(sentence == 1 && player.getPLayerState() == "Walk"){
                StartCoroutine("betweenSentence"); 
                endSentence = false;
            } else if(sentence == 3 && player.getPLayerState() == "Jump"){
                StartCoroutine("betweenSentence"); 
                endSentence = false;
            } else if(sentence == 5 && player.getPLayerState() == "DoubleJump"){
                StartCoroutine("betweenSentence"); 
                endSentence = false;
            } else if(sentence == 7 && player.getPLayerState() == "Block"){
                StartCoroutine("betweenSentence"); 
                endSentence = false;
            } else if(sentence == 9 && player.getPLayerState() == "Roll"){
                StartCoroutine("betweenSentence"); 
                endSentence = false;
            } else if(sentence == 11 && player.getPLayerState() == "Dash"){
                StartCoroutine("betweenSentence"); 
                endSentence = false;
            } else if(sentence == 13 && player.getPLayerState() == "AttackOne" || player.getPLayerState() == "AttackTwo"){
                StartCoroutine("betweenSentence"); 
                endSentence = false;
            } else if(sentence == 15 && player.getPLayerState() == "AttackAir"){
                StartCoroutine("betweenSentence"); 
                endSentence = false;
            } else if (sentence == 16){
                StartCoroutine("startGame");
            } 
       
        } 
        
    }

    private void startEnemies(){
        enemies.SetActive(true);
    }

    IEnumerator Wait(){
        
        foreach(char letter in messages[sentence].ToCharArray()){
            tutorialText.text += letter;
            yield return new WaitForSeconds(.1f);
            
        }
        endSentence = true;
    }

    IEnumerator betweenSentence(){
       yield return new WaitForSeconds(1f); 
       nextSentence(); 
    }

    IEnumerator startGame(){
       yield return new WaitForSeconds(1f); 
       tutorialText.text = "";
        tutorialWall.SetActive(false);
        signPost.SetActive(true);
        if (player.transform.position.x > -10){
            startEnemies();
        }
    
    }

    

    void OnEnable(){
        playerTutorial = PlayerPrefs.GetInt("tutorial");
    }

    void nextSentence(){
        if (sentence < messages.Length -1){
            sentence ++;
            tutorialText.text = "";
            StartCoroutine("Wait"); 
        }
    }
   
}
