using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    [SerializeField] private AudioSource pickUpPowerUp;
    void Start()
    {
        pickUpPowerUp.Play();
    }

}
