using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeerController : MonoBehaviour
{   
    public Slider healtSlider;
    public float beerOneAddLife = 20;
    [SerializeField] PlayerController playerController;
    [SerializeField] Transform beerOne;
    [SerializeField] GameObject empyBeer;
   

    void Start(){
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    
    

    public void AddLife(){
        healtSlider.value += beerOneAddLife * 0.01f;;
        playerController.healt += beerOneAddLife;
    }
    
    private void GenerateEmpyBeer(){
        Instantiate(empyBeer, beerOne.position, beerOne.rotation);
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            AddLife();
            Destroy(gameObject);
            GenerateEmpyBeer();
           

        }

    }

    
}