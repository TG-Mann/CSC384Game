using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class FlyingEyeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject explosion2;

    // Update is called once per frame
    void Awake()
    {
        speed = Random.Range(1,10);   
    }
    void FixedUpdate()
    {
        movePLatform();
    }

    private void movePLatform(){
        if (transform.position.x < 50){
            transform.position = new Vector2(transform.position.x + (speed / 100), transform.position.y);
        } else{
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision){

        if (collision.gameObject.CompareTag("Player")){
            string playerState = collision.GetComponent<Player>().getPLayerState();
            if (playerState != "AttackOne" && playerState != "AttackTwo"  && playerState != "AttackAir" && playerState != "Block" && !(collision.GetComponent<Player>().getPlayerSize() == Player.PlayerSize.large) && !collision.GetComponent<Player>().getIsInvisible()){
                collision.GetComponent<Player>().setHit(true);
            }
            if (!collision.GetComponent<Player>().getIsInvisible()){
                if (playerState != "AttackOne" && playerState != "AttackTwo"  && playerState != "AttackAir" && playerState != "Block" && !(collision.GetComponent<Player>().getPlayerSize() == Player.PlayerSize.large)){
                    Instantiate(explosion, collision.transform);
                } else {
                    Instantiate(explosion2, transform.position, transform.rotation);
                }
                Destroy(this.gameObject);
            }
           
        } 
        

    }
}
