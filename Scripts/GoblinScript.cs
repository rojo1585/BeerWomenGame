using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScript : MonoBehaviour
{   
    public GameObject Player;
    [Header("AontrolAttack")]
    [SerializeField] private Transform controllerAtackEnemy;
    [SerializeField] private float radioAtack;
    [SerializeField] private float damageHitGoblin;
    [SerializeField] private float timeBetweenAtack;
    [SerializeField] private float timeNextAtack;
    PlayerController playerController;
    [SerializeField] private int numAtack;
    public float speed;
    
    [SerializeField] private float rangeVision;
    [SerializeField] private float distancePlayer;
    Vector3 direction;
    
    
    //[SerializeField] private float healt;
    //[SerializeField] private float prevHealt;
     private Animator animator;
    // Start is called before the first frame update
    void Start()
    {   
        Player = GameObject.Find("Player");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        numAtack = Random.Range(1,3);
        radioAtack = 0.1f;
        damageHitGoblin = 15.0f;
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
            GetComponent<EnemyController>().MakeHit(damageHitGoblin,controllerAtackEnemy, radioAtack);
            numAtack = Random.Range(1,3);                      
        }
  
    }
    //hace un mapeo de colicion y al colicionar con alo con la etiqueta player manda a llamar el metodo para restar vida al jugador
    
    
    private void SelectAtackGoblin(){
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
