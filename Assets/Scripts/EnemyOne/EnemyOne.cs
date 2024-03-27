using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    private IEnemyOneState currentState = new EnemyOneIdle();

    [SerializeField] private Animator animator; 

    private SpriteRenderer sprite;

    private string enemyOneState;

    GameObject player;

    bool dead;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        setEnemyOneState("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        updateState();
        currentState.frameUpdate();
        print(distanceToPlayer());
    }

    void FixedUpdate()
    {
        currentState.physicsUpdate();
    }

    private void updateState(){

        IEnemyOneState newState = currentState.Tick(this, animator);

        if (newState != null){
            currentState.Exit(this);
            currentState = newState;
            newState.Enter(this);
        }
    }


    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
            string playerState = collision.GetComponent<Player>().getPLayerState();
            if (playerState == "AttackOne" || playerState == "AttackTwo"  || playerState == "AttackAir"){
                dead = true;
            }
        }
    }

    public float distanceToPlayer(){
        return Vector2.Distance(transform.position, player.transform.position);
       
    }

    public string getEnemyOneState(){
        return enemyOneState;
    }

    public void setEnemyOneState(string newState){
        enemyOneState = newState;
    }

    public bool isDead(){
        if (dead){
            return true;
        } 
        return false;
    }
}
