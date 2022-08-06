using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    private Animator animator;
    
    [SerializeField] GameObject mushroomBullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDamage;
    [SerializeField] private float timeToDestroyBullet;
    Vector3 direction;

    GameObject Player;

    private bool destro;
    void Start()
    {
        animator = GetComponent<Animator>();
        Player = GameObject.Find("Player");
        
        destro = false;
        bulletDamage = 30;
        
    }

    void Update()
    {   

        direction = Player.transform.position - transform.position;

        if(destro == false && direction.x >= 0.0f){
            transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
             
        }else if(destro == false){
            transform.Translate(Vector3.left * bulletSpeed * Time.deltaTime);
        }
        
        timeToDestroyBullet -= Time.deltaTime;
        if(destro == true && timeToDestroyBullet <= 0)
        {
            Destroy(gameObject);
        }

        
        
    }

  
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            collision.GetComponent<PlayerController>().TakeDamagePlayer(bulletDamage);
            animator.SetBool("DestroyBullet",true); 
            destro = true;
            timeToDestroyBullet = .3f;
            transform.Translate(Vector3.right * 0);  
        }


    }




  
}
