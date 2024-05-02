using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadGame : MonoBehaviour
{

    [SerializeField] CameraMovementBehaviour script;
    [SerializeField] Player player;
    [SerializeField] PlayerCollision playerCollision;

    int playerTutorial; // if tutorial is played must be new game

    void Start()
    {
        if (playerTutorial == 0 && File.Exists(Application.dataPath + "/save.txt")){
            string savedString = File.ReadAllText(Application.dataPath + "/save.txt");

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(savedString);

            while (player.getLives() > saveObject.numLives){
                player.takeLife();
            }
            player.transform.position = new Vector3(saveObject.playerX + 0.7f, saveObject.playerY, player.transform.position.z);

            if (saveObject.hasGhost){
                playerCollision.setHasInvicibleItem();
            }
            if (saveObject.hasSmall){
                playerCollision.setHasSmallItem();
            }
            if (saveObject.hasLarge){
                playerCollision.setHasLargeItem();
            }

            if (saveObject.playerX > 25){
                script.moveCamera(33.3f, -0.7f);
            } else if (saveObject.playerX > 8){
                script.moveCamera(16.7f, 5.8f);
            } else{
                script.moveCamera(0.3f, -0.2f);
            }
        }

    }

    void OnEnable(){
        playerTutorial = PlayerPrefs.GetInt("tutorial");
    }
}
