using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeerController : MonoBehaviour
{   
   
    public float beerOneAddLife = 20;
    [SerializeField] PlayerController playerController;
    [SerializeField] Transform beerOne;
    [SerializeField] GameObject empyBeer;
   

    void Start(){
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    
    

    
    private void GenerateEmpyBeer(){
        Instantiate(empyBeer, beerOne.position, beerOne.rotation);
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            playerController.AddLife(beerOneAddLife);
            Destroy(gameObject);
            GenerateEmpyBeer();
           

        }

    }

    
}
