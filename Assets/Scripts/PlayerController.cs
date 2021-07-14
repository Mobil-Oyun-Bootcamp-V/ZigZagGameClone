using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    Vector3 orientation;
    public static bool gameOver;
    public TileSpawner ts;

    // Start is called before the first frame update
    void Start()
    {
        orientation = Vector3.forward;
        gameOver = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        gameOver = transform.position.y < 0.5f ? true : false;
        if (gameOver) return;
        if(Input.GetMouseButtonDown(0)){
            if(orientation.x == 0){
                orientation = Vector3.left;
            }
            else{
                orientation = Vector3.forward;
            }
        }
        velocity+= 0.05f * Time.deltaTime;
    }
    private void FixedUpdate(){
     Vector3 movement = orientation * Time.deltaTime * velocity;
     transform.position+= movement;
    }

    private void OnCollisionExit(Collision cl){
        if(cl.gameObject.tag == "minitile"){
         ts.CreateTile();
         cl.gameObject.AddComponent<Rigidbody>();
         StartCoroutine(DeleteTile(cl.gameObject));
         Scoring.score+=1;
        }
    }

    IEnumerator DeleteTile(GameObject go) {
    yield return new WaitForSeconds(3f);
    Destroy(go);
    }
}
