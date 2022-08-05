using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    public GameObject Player;
    private Animator animator;
    [SerializeField] private Transform controllerAtackEnemy;
    [SerializeField] private float radioAtack;
    [SerializeField] private float damageHitMushroom;
    [SerializeField] private float timeBetweenAtack;
    [SerializeField] private float timeNextAtack;
    [SerializeField] private int numAtack;

    PlayerController playerController;

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
        radioAtack = 0.2f;
        damageHitMushroom = 40.0f;
        timeBetweenAtack = 2.4f;
        speed = 1.0f;
        rangeVision = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //obtener ubicacion del jugador
        direction = Player.transform.position - transform.position;

        //Evaluar si el jugador esta dentro del rango de ataque o no 
        distancePlayer= Vector2.Distance(transform.position,Player.transform.position);
        if(distancePlayer <  rangeVision && Mathf.Abs(distancePlayer) > 0.2f && playerController.life == true && GetComponent<EnemyController>().isDeadEnemy == false) {
            GetComponent<EnemyController>().Run();
            GetComponent<EnemyController>().FollowPlayer(speed,direction);
            
        }else{
            GetComponent<EnemyController>().DontFollowPlayer(direction);
            GetComponent<EnemyController>().NoRun();

        }

        timeNextAtack -= Time.deltaTime;
        if(timeNextAtack <=  0 && playerController.healt >= 0 && Mathf.Abs(distancePlayer) < 1){     
            if(timeNextAtack <= 0 && numAtack == 1 && GetComponent<EnemyController>().healt > 0){GetComponent<EnemyController>().AtackOne(); timeNextAtack = timeBetweenAtack;}
            if(timeNextAtack <= 0 && numAtack == 2 && GetComponent<EnemyController>().healt > 0){GetComponent<EnemyController>().AtackTwo(); timeNextAtack = timeBetweenAtack; }
            HitMushroom();
            numAtack = Random.Range(1,3);                      
        }

        
    }

    private void HitMushroom(){
        Collider2D[] objects = Physics2D.OverlapCircleAll(controllerAtackEnemy.position, radioAtack);

        foreach(Collider2D colision in objects){
            if(colision.CompareTag("Player") && GetComponent<EnemyController>().isDeadEnemy == false){
                colision.transform.GetComponent<PlayerController>().TakeDamagePlayer(damageHitMushroom);
                colision.transform.GetComponent<PlayerController>().TakeHitPlayer();
                
            }
            
        }
    }

     private void SelectAtackMushroom(){
        if(GetComponent<EnemyController>().healt > 0  ){
            if(timeNextAtack <= 0 && numAtack == 1){ animator.SetTrigger("AtackOne"); timeNextAtack = timeBetweenAtack; }
            if(timeBetweenAtack <= 0 && numAtack == 2){animator.SetTrigger("AtackTwo"); timeNextAtack = timeBetweenAtack; }
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controllerAtackEnemy.position, radioAtack);
    }
}
