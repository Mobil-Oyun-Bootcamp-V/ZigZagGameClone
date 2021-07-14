using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lastTile;
    void Start()
    {
       for(int i=0;i<15;i++){
        CreateTile();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void CreateTile(){
        Vector3 orient;
        orient = Random.Range(0,2) == 0 ? Vector3.forward : Vector3.left;
        lastTile = Instantiate(lastTile,lastTile.transform.position+orient,lastTile.transform.rotation);
        lastTile.tag = "minitile";
    }
}
