using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    private Animator animator;
    public Slider healtSlider;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject mushroomBullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDamage;
    [SerializeField] private float timeToDestroyBullet;

    private bool destro;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        
        destro = false;
        bulletDamage = 30;
    }

    void Update()
    {   
        if(destro == false){
            transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
           // transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
        }
        
        timeToDestroyBullet -= Time.deltaTime;
        if(destro == true && timeToDestroyBullet <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    private void Damage(){
        healtSlider.value -= bulletDamage * 0.01f;;
        playerController.healt -= bulletDamage;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            animator.SetBool("DestroyBullet",true); 
            destro = true;
            timeToDestroyBullet = .3f;
            transform.Translate(Vector3.right * 0);
            Damage();
        }

    }


  
}
