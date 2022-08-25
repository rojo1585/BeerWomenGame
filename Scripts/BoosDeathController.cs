using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosDeathController : MonoBehaviour
{

    public GameObject Player;
    private Animator animator;

    [SerializeField] private Transform controllerAtackEnemy;
    
    
    [SerializeField] private float radioAtack;
    [SerializeField] private float damageHitBoss;
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
        damageHitBoss = 40.0f;
        timeBetweenAtack = 2.4f;
        speed = 1.0f;
        rangeVision = 2.0f;
        
    }

    // Update is called once per frame
    void Update()
    {

        direction = Player.transform.position - transform.position;
      

        //Evaluar si el jugador esta dentro del rango de ataque o no 
        distancePlayer = Vector2.Distance(transform.position,Player.transform.position);
        if(distancePlayer <  rangeVision && Mathf.Abs(distancePlayer) > 0.2f && playerController.life == true && GetComponent<EnemyController>().isDeadEnemy == false) {
            GetComponent<EnemyController>().Run();
            GetComponent<EnemyController>().FollowPlayer(speed,direction);
          
            
        }else{
            GetComponent<EnemyController>().DontFollowPlayer(direction);
            GetComponent<EnemyController>().NoRun();

        }
        
    }
}
