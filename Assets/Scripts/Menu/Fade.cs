using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{

    [SerializeField] private GameObject fade;

     public void disableEvent(){
        fade.SetActive(false);
    }
}
