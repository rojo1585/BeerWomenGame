using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScript : MonoBehaviour
{   
    public GameObject Player;
    [SerializeField] private Transform controllerAtackEnemy;
    [SerializeField] private float radioAtack;
    [SerializeField] private float damageHitGoblin;
    [SerializeField] private float timeBetweenAtack;
    [SerializeField] private float timeNextAtack;
    
    
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

       

        timeNextAtack -= Time.deltaTime;
        if(timeNextAtack <=  0){
            HitGlobin();
            SelectAtackGoblin();
        }
            
        
        
    }
    //hace un mapero de colicion y al colicionar con alo con la etiqueta player manda a llamar el metodo para restar vida al jugador
    private void HitGlobin(){
        Collider2D[] objects = Physics2D.OverlapCircleAll(controllerAtackEnemy.position, radioAtack);

        foreach(Collider2D colision in objects){
            if(colision.CompareTag("Player") && GetComponent<EnemyController>().isDeadEnemy == false){
                colision.transform.GetComponent<PlayerController>().TakeDamagePlayer(damageHitGoblin);
                colision.transform.GetComponent<PlayerController>().TakeHitPlayer();
            }
            
        }
    }
    
    private void SelectAtackGoblin(){
        if(GetComponent<EnemyController>().healt > 0){
            if(timeNextAtack <= 0){ animator.SetTrigger("AtackOne"); timeNextAtack = timeBetweenAtack;}
        }
        
       
    }

    
    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controllerAtackEnemy.position, radioAtack);
    }
}
