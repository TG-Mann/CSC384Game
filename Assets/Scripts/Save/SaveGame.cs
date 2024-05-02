using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision){

        if (collision.gameObject.CompareTag("Player")){

            Player player = collision.gameObject.GetComponent<Player>();
            PlayerCollision playerColllision = collision.gameObject.GetComponent<PlayerCollision>();

            SaveObject saveObject = new SaveObject(collision.transform.position.x, collision.transform.position.y,
                player.getLives(), playerColllision.getHasInvicibleItem(), playerColllision.getHasLargeItem(), playerColllision.getHasSmallItem());

            string Json = JsonUtility.ToJson(saveObject);
            
            File.WriteAllText(Application.dataPath + "/save.txt", Json);
            print(Application.dataPath);
        } 

    }

     
    
}
