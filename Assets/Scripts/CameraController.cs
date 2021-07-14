using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerPosition;
    Vector3 diff;
    void Start()
    {
       diff = transform.position - playerPosition.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerController.gameOver){
        transform.position = playerPosition.position + diff;
        }
        
    }
}
