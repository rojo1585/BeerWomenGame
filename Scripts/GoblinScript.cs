using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScript : MonoBehaviour
{   
    public GameObject Player;
    [SerializeField] private Transform controllerAtackEnemy;
    [SerializeField] private float radioAtack;
    [SerializeField] private float damageHitGoblin;
    
    
    //[SerializeField] private float healt;
    //[SerializeField] private float prevHealt;
     private Animator animator;
    // Start is called before the first frame update
    void Start()
    {   
      
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //mantener mirando siempre al jugador
        Vector3 direction = Player.transform.position - transform.position;
        if(direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else    transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        if(Input.GetButtonDown("Fire2")){HitGlobin();}
        
    }

    private void HitGlobin(){
        Collider2D[] objects = Physics2D.OverlapCircleAll(controllerAtackEnemy.position, radioAtack);

        foreach(Collider2D colision in objects){
            if(colision.CompareTag("Player")){
                colision.transform.GetComponent<PlayerController>().TakeDamagePlayer(damageHitGoblin);
                
            }
            
        }
    }

    
    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controllerAtackEnemy.position, radioAtack);
    }
}
