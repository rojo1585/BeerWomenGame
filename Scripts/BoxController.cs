 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{   
    
    
    [SerializeField] private GameObject newBox;
 
    //private int healt = 5;
    // Start is called before the first frame update
    private void Awake(){
        
    }
 
    public void DestroyBox(){
        Destroy(gameObject);
        
    }

    public void CreateBox(){
        Instantiate(newBox, transform.position, Quaternion.identity);
    }
    private void OnCollisionEneter2D(Collision2D collision){
        //if(collision.("Player")){DestroyBox();}
    }
}
