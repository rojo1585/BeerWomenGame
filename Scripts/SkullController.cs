using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullController : MonoBehaviour
{

    [SerializeField] private Transform player;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
   
    private float damage;
     // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        damage = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnSkull(Vector3 target){
        if(transform.position.x > target.x){spriteRenderer.flipX = true;}else{spriteRenderer.flipX = false;}
    }

    private void DestroySkull(){
        Destroy(gameObject);
    }

    private void MakeDamage(){
        //
       
    }


    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            animator.SetBool("Destroy",true);
            collision.GetComponent<PlayerController>().TakeDamagePlayer(damage);
        }
    }

}
