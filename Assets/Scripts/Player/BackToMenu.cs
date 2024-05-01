using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class BackToMenu : MonoBehaviour
{

    [SerializeField] private GameObject deathMessage;
    [SerializeField] private GameObject winMessage;

    Player player;

    void Awake(){
        player = GameObject.FindAnyObjectByType<Player>();
    }

    void Update()
    {

        if(player.getLives() == 0){
            deathMessage.SetActive(true);
            StartCoroutine("Wait");
        }
        
        
    }


    public void OnTriggerEnter2D(Collider2D collision){

        if (collision.gameObject.CompareTag("Player")){
            if (gameObject.tag == "Death"){
                deathMessage.SetActive(true);
                StartCoroutine("Wait");
            } else if(gameObject.tag == "Finish"){
                winMessage.SetActive(true);
                StartCoroutine("Wait");
            }
          
          
        } 

    
    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(2f);
        deathMessage.SetActive(false);
        winMessage.SetActive(false);
        SceneManager.LoadScene("Main_Menu");
        
    }

    
}
