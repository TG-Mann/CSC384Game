using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IPlayerState currentState = new PlayerIdle();

    // Update is called once per frame
    void Update()
    {
        updateState();
    }

    private void updateState(){
        IPlayerState newState = currentState.Tick(this);

        if (newState != null){
            currentState.Exit(this);
            currentState = newState;
            print(currentState);
            newState.Enter(this);
        }
    }
}
