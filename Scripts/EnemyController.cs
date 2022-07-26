using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] public float healt;
    private Animator animator;
    
    
    public bool isDeadEnemy = false;
    public float timeToDestroyEnd;
   


    [SerializeField] 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Player = GameObject.Find("Player");
        timeToDestroyEnd = 10.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if(healt <=0){
            timeToDestroyEnd -= Time.deltaTime;
            Dead();
        }
    }

    public void TakeDamage(float damage){
        healt -= damage;
        if(healt <= 0){
            Dead();
        }
        
    }

    private void Dead(){
        animator.SetTrigger("Dead");
        isDeadEnemy = true;
         if(timeToDestroyEnd <= 0){
            Destroy(gameObject);

        }
    }

    public void AtackOne(){
        animator.SetTrigger("AtackOne");
    }

    public void AtackTwo(){
        animator.SetTrigger("AtackTwo");
    }
    public void TakeHit(){animator.SetTrigger("TakeHit");}

    public void Run(){animator.SetBool("Run",true);}
    public void NoRun(){animator.SetBool("Run",false);}


    //Girar al enemigo a ver al jugador y seguir si esnta en el rango de vicion
    public void FollowPlayer(float speed , Vector3 direction){ 
       if(direction.x >= 0.0f ){ 
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            transform.Translate(Vector3.right* speed * Time.deltaTime);
            
        }
        else{ 
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f); 
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            
        }
    }

    public void DontFollowPlayer(Vector3 direction){;
        if(direction.x >= 0.0f && GetComponent<EnemyController>().isDeadEnemy == false){ 
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);   
        }
        else{ 
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);         
        }
    }

    public void MakeHit(float dmg, Transform controllerAtackEnemy, float radioAtack){
        Collider2D[] objects = Physics2D.OverlapCircleAll(controllerAtackEnemy.position, radioAtack);

        foreach(Collider2D colision in objects){
            if(colision.CompareTag("Player") && GetComponent<EnemyController>().isDeadEnemy == false){
                colision.transform.GetComponent<PlayerController>().TakeDamagePlayer(dmg);
                colision.transform.GetComponent<PlayerController>().TakeHitPlayer();
                
            }
            
        }
    }
    
    

}
