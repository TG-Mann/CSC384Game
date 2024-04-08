using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCollision : MonoBehaviour
{

    private Rigidbody2D rb;

    private bool isBig;
    private bool isSmall;

    [SerializeField] Player player;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
      
    }

    void Update(){

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("HorizontalPlatform")){

           this.transform.parent = collision.transform;
          
        } 

        if (collision.gameObject.tag == "SmallItem"){
            playerSmall();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "BigItem"){
            playerBig();
            collision.gameObject.SetActive(false);
        }
    }

    private void playerSmall(){
        spriteRenderer.transform.localScale = new Vector2(0.8f,0.8f);
        isSmall = true;
        player.setSpeed(5);
        player.setJump(6);
        StartCoroutine("Wait");
    }

     private void playerBig(){
        spriteRenderer.transform.localScale = new Vector2(3f,3f);
        isBig = true;
        player.setSpeed(1);
        StartCoroutine("Wait");
    }

    public void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.CompareTag("HorizontalPlatform")){
            this.transform.parent = null;
        }
    }

      IEnumerator Wait(){
        yield return new WaitForSeconds(4f);
        spriteRenderer.transform.localScale = new Vector2(1.5f, 1.5f);
        isSmall = false;
        isBig = false;
        player.setSpeed(2);
        player.setJump(4);
    }

    public bool getIsBig(){
        return isBig;
    }

    public bool getIsSmall(){
        return isSmall;
    }
}
