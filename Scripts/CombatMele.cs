using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMele : MonoBehaviour
{
    [SerializeField] private Transform controllerAtack;
    [SerializeField] private float radioAtack;
    [SerializeField] private float damageHitGoblin;
    [SerializeField] private float damageHitPlayerBasicAtack;
    [SerializeField] private float damageHitPlayerDashAtack;
    public float timeBetweenHit;
    public float timeNextHit;
    public float timeBetweenHitDash; 
    public float timeNextHitDash;

    


   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  

        
        if(timeNextHit > 0 || timeNextHitDash > 0){timeNextHit -= Time.deltaTime; timeNextHitDash -= Time.deltaTime;}
        Hit();
        
    }
    //Hhacer daño dependiendo del golpe
    private void Hit(){
        Collider2D[] objects = Physics2D.OverlapCircleAll(controllerAtack.position, radioAtack);

        foreach(Collider2D colision in objects){
            if(colision.CompareTag("Enemy")){
                if(Input.GetButtonDown("Fire1") && timeNextHit <=0){
                    colision.transform.GetComponent<EnemyController>().TakeDamage(damageHitPlayerBasicAtack);
                    colision.transform.GetComponent<EnemyController>().TakeHit();
                    timeNextHit = timeBetweenHit;
                }else if(Input.GetButtonDown("Fire2") && timeNextHitDash <= 0){
                    colision.transform.GetComponent<EnemyController>().TakeDamage(damageHitPlayerDashAtack);
                    colision.transform.GetComponent<EnemyController>().TakeHit();
                    timeNextHitDash = timeBetweenHitDash;
                }
                
            }

            
        }
    }

    

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controllerAtack.position, radioAtack);
    }
}
