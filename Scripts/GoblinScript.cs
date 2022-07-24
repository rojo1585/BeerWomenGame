using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScript : MonoBehaviour
{   
    public GameObject Player;
    [SerializeField] private float healt;
    [SerializeField] private float prevHealt;
     private Animator animator;
    // Start is called before the first frame update
    void Start()
    {   
        prevHealt = healt;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = Player.transform.position - transform.position;
        if(direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else    transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        
    }

    public void TakeDamage(float damage){
        healt -= damage;
        if(healt <= 0){
            Dead();
        }
    }

    public void IsHite(){animator.SetTrigger("IsHit");}
    private void Dead(){
        animator.SetTrigger("Dead");
    }
}
