using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosDeathController : MonoBehaviour
{

    public GameObject Player;
    private Animator animator;
    [SerializeField] private GameObject spell;

    [SerializeField] private Transform controllerAtackEnemy;
    [SerializeField] private Transform ControlCast;
    
    
    [SerializeField] private float radioAtack;
    [SerializeField] private float damageHitBoss;
    [SerializeField] private float timeBetweenAtack;
    [SerializeField] private float timeNextAtack;
    [SerializeField] private int numAtack;

    PlayerController playerController;
    
    
    private bool isDeadEnemy ;
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float rangeVision;
    [SerializeField] private float distancePlayer;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        numAtack = Random.Range(1,3);
        damageHitBoss = 40.0f;
        timeBetweenAtack = 2.4f;
        speed = 1.0f;
        rangeVision = 2.0f;
        isDeadEnemy = false;
        radioAtack = 0.3f;
        
    }

    // Update is called once per frame
    void Update()
    {

        direction = Player.transform.position - transform.position;
        
      
    
        //Evaluar si el jugador esta dentro del rango de ataque o no 
        distancePlayer = Vector2.Distance(transform.position,Player.transform.position);
        if(distancePlayer <  rangeVision && Mathf.Abs(distancePlayer) > 0.5f && playerController.life == true && isDeadEnemy == false) {
            Run();
            DistanceForCast();
            
        }else{
            NoRun();
            DontFollowPlayer();

        }
        
    }
    private void CastSpell(){
       
        Instantiate(spell, ControlCast.position, ControlCast.rotation);
    }
    private void Run(){animator.SetBool("Run", true);}
    private void NoRun(){animator.SetBool("Run", false);}
    private void DistanceForCast(){ 
       if(direction.x >= 0.0f ){ 
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            transform.Translate(Vector3.left* speed * Time.deltaTime);
            
        }
        else{ 
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f); 
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            
        }
    }

    public void DontFollowPlayer(){;
        if(direction.x >= 0.0f && isDeadEnemy == false){ 
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);   
        }
        else{ 
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);         
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controllerAtackEnemy.position, radioAtack);
      
    }

    private void MakeHitBoss(){
        Collider2D[] objects = Physics2D.OverlapCircleAll(controllerAtackEnemy.position, radioAtack);

        foreach(Collider2D colision in objects){
            if(colision.CompareTag("Player") && GetComponent<EnemyController>().isDeadEnemy == false){
                colision.transform.GetComponent<PlayerController>().TakeDamagePlayer(damageHitBoss);
                colision.transform.GetComponent<PlayerController>().TakeHitPlayer();
                
            }
            
        }
    }

}
