using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        StartCoroutine(Example());
      
        //transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        
    }

    IEnumerator Example()
    {
        print(Time.time);
        
        yield return new WaitForSeconds(5);
        transform.position = new Vector3(transform.position.x, 5, transform.position.z);
    }
}





