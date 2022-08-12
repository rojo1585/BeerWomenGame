using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{   
    
    
    [SerializeField] private GameObject boxTwo;
 
    //private int healt = 5;
    // Start is called before the first frame update
    private void Awake(){
        
    }
 
    public void DestroyBox(){
        
        Instantiate(boxTwo, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnCollisionEneter2D(Collision2D collision){
        //if(collision.("Player")){DestroyBox();}
    }
}
