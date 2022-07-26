using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public float healt;
    private Animator animator;
    public bool isDeadEnemy = false;
    public float timeToDestroyEnd;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

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


    public void TakeHit(){animator.SetTrigger("TakeHit");}
    
}
