using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] Player player;

    [SerializeField] private GameObject powerUpEffect1;
    [SerializeField] private GameObject powerUpEffect2;
    [SerializeField] private GameObject powerUpEffect3;
    [SerializeField] private AudioSource audioPowerUp1;
    [SerializeField] private AudioSource audioPowerUp2;
    [SerializeField] private AudioSource audioPowerUp3;
    [SerializeField] private AudioSource pickUpPowerUp;

    private SpriteRenderer spriteRenderer;

    private bool hasInvicibleItem = false;
    private bool hasLargeItem = false;
    private bool hasSmallItem = false;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update(){
        if (hasLargeItem && Input.GetKeyUp(KeyCode.Alpha2)){
            Instantiate(powerUpEffect1, transform.position, transform.rotation);
            audioPowerUp1.Play();
            new GrowItem().Activate(spriteRenderer);
            StartCoroutine("Wait");
            hasLargeItem = false;
        }
        if (hasSmallItem && Input.GetKeyUp(KeyCode.Alpha3)){
            Instantiate(powerUpEffect2, transform.position, transform.rotation);
            audioPowerUp3.Play();
            new ShrinkItem().Activate(spriteRenderer);
            StartCoroutine("Wait");
            hasSmallItem = false;
        }
        if (hasInvicibleItem && Input.GetKeyUp(KeyCode.Alpha1)){
            Instantiate(powerUpEffect3, transform.position, transform.rotation);
            audioPowerUp2.Play();
            new InvisibleItem().Activate(spriteRenderer);
            StartCoroutine("Wait");
            hasInvicibleItem = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HorizontalPlatform")){
           this.transform.parent = collision.transform;
   
        } 
        if (collision.gameObject.CompareTag("VerticalPlatform")){
           this.transform.parent = collision.transform;
   
        }
        if (collision.gameObject.tag == "SmallItem"){
            if (!hasSmallItem){
                pickUpPowerUp.Play();
                collision.gameObject.SetActive(false);
                hasSmallItem = true;
            }
            
        }
        if (collision.gameObject.tag == "BigItem"){
            if (!hasLargeItem){
                pickUpPowerUp.Play();
                collision.gameObject.SetActive(false);
                hasLargeItem = true;
            }
            
        }
        if (collision.gameObject.tag == "InvisibleItem"){
            if (!hasInvicibleItem){
                pickUpPowerUp.Play();
                collision.gameObject.SetActive(false);
                hasInvicibleItem = true;
            }
            
        }
    }

    public void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.CompareTag("HorizontalPlatform")){
            this.transform.parent = null;
        }
        if (collision.gameObject.CompareTag("VerticalPlatform")){
            this.transform.parent = null;
        }
    }

    public bool getHasInvicibleItem(){
        return hasInvicibleItem;
    }
     public bool getHasSmallItem(){
        return hasSmallItem;
    }
     public bool getHasLargeItem(){
        return hasLargeItem;
    }

    public void setHasInvicibleItem(){
        hasInvicibleItem = true;
    }
     public void setHasSmallItem(){
        hasSmallItem = true;
    }
     public void setHasLargeItem(){
        hasLargeItem = true;
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(4f);
        new NormalItem().Activate(spriteRenderer);
    }


}
