using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    Animator animator;
    PlayerController playerController;
    Rigidbody2D rb2D;


    void Awake(){
        rb2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroySpikes(){
        Destroy(gameObject);
    }
    public void FallSpike(){
        rb2D.gravityScale = 0.5f;
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Ground")){
            animator.SetTrigger("Broken");
        }else if(collision.CompareTag("Player")){playerController.TakeDamagePlayer(50);}
    }
}
