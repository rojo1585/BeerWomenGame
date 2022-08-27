using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMele : MonoBehaviour
{
    [SerializeField] private Transform controllerAtack;
    [SerializeField] private float radioAtack;
    
    [SerializeField] private float damageHitPlayerBasicAtack;
    [SerializeField] private float damageHitPlayerDashAtack;
    public float timeBetweenHit;
    public float timeNextHit;
    public float timeBetweenHitDash; 
    public float timeNextHitDash;

    // Start is called before the first frame update
    void Start()
    {
        radioAtack = 0.2f;
        damageHitPlayerBasicAtack = 15;
        damageHitPlayerDashAtack = 30;
        timeBetweenHit = .6f;
        timeBetweenHitDash = 1.5f;
        
    }

    // Update is called once per frame
    void Update()
    {  

        
        if(timeNextHit > 0 || timeNextHitDash > 0){timeNextHit -= Time.deltaTime; timeNextHitDash -= Time.deltaTime;}
        
        ControlAnimationAtack();
        
    }
    //Hhacer daño dependiendo del golpe
    private void Hit(){
        Collider2D[] objects = Physics2D.OverlapCircleAll(controllerAtack.position, radioAtack);

        foreach(Collider2D colision in objects){
            if(colision.CompareTag("Enemy")){                    
                colision.transform.GetComponent<EnemyController>().TakeDamage(damageHitPlayerBasicAtack);
                colision.transform.GetComponent<EnemyController>().TakeHit();    
            }
        }
    }

    private void HitDash(){
        Collider2D[] objects = Physics2D.OverlapCircleAll(controllerAtack.position, radioAtack);

        foreach(Collider2D colision in objects){
            if(colision.CompareTag("Enemy")){         
                colision.transform.GetComponent<EnemyController>().TakeDamage(damageHitPlayerDashAtack);
                colision.transform.GetComponent<EnemyController>().TakeHit();
            }
        }
    }

    private void HitBullet(){
        Collider2D[] objects = Physics2D.OverlapCircleAll(controllerAtack.position, radioAtack);

        foreach(Collider2D colision in objects){
            if(colision.CompareTag("Bullet")){         
                colision.transform.GetComponent<SkullController>().DestroySkull();
                
            }
        }

    }
    //Controlar animaciones dependiendo del golpe realizado
    private void ControlAnimationAtack(){
        if(Input.GetButtonDown("Fire1")  && timeNextHit <=0 ){
            GetComponent<PlayerController>().AtackOne();
             timeNextHit = timeBetweenHit;
        }else if(Input.GetButtonDown("Fire2") && timeNextHitDash <= 0){
            GetComponent<PlayerController>().AtackDash();
            timeNextHitDash = timeBetweenHitDash;
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controllerAtack.position, radioAtack);
    }
}
