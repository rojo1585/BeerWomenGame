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
        healt = 100;
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

    
    

}
