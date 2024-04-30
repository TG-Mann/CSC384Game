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

    Player player;

    bool dead;

    private int timeSinceAttack = 1000;

    void Awake()
    {
        player = GameObject.FindAnyObjectByType<Player>();
        sprite = GetComponent<SpriteRenderer>();
        setEnemyOneState("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        updateState();
        currentState.frameUpdate();
        
    }

    void FixedUpdate()
    {
        currentState.physicsUpdate();
        timeSinceAttack ++;
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
            if (playerState == "AttackOne" || playerState == "AttackTwo"  || playerState == "AttackAir" || collision.GetComponent<Player>().getPlayerSize() == Player.PlayerSize.large){
                dead = true;
            }
            if (enemyOneState == "Attack"){
                if (!(collision.GetComponent<Player>().getPlayerSize() == Player.PlayerSize.large) && !collision.GetComponent<Player>().getIsInvisible()){
                     collision.GetComponent<Player>().setHit(true);
                }
                
            }
        }
    }

    public float distanceToPlayer(){
        if (player.getIsInvisible()){
            return 1000;
        } 
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

    public int getTimeSinceAttack(){
        return timeSinceAttack;
    }

    public void setTimeSinceAttack(int newTime){
        timeSinceAttack = newTime;
    }
}
