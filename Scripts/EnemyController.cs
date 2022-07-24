using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float healt;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage){
        healt -= damage;
        if(healt <= 0){
            Dead();
        }
    }

    private void Dead(){
        animator.SetTrigger("Dead");
    }
}
