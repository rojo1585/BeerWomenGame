using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMele : MonoBehaviour
{
    [SerializeField] private Transform controllerAtack;
    [SerializeField] private float radioAtack;
    [SerializeField] private float damageHit;
    private GoblinScript goblinScript;


    // Start is called before the first frame update
    void Start()
    {
        goblinScript = GetComponent<GoblinScript>();   
    }

    // Update is called once per frame
    void Update()
    {  
        if(Input.GetButtonDown("Fire1")){Hit();}
        
    }

    private void Hit(){
        Collider2D[] objects = Physics2D.OverlapCircleAll(controllerAtack.position, radioAtack);

        foreach(Collider2D colision in objects){
            if(colision.CompareTag("Enemy")){
                colision.transform.GetComponent<EnemyController>().TakeDamage(damageHit);
                goblinScript.IsHite();

            }
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controllerAtack.position, radioAtack);
    }
}
