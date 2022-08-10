using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] private float radio;
    [SerializeField] private float burstForece;
    [SerializeField] private GameObject burstEfect;


    private void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){Burst();}
    
    }
    public void Burst(){
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radio);
        //f
        //f
        foreach(Collider2D collision in objects){
            Rigidbody2D rb2D = collision.GetComponent<Rigidbody2D>();
            if(rb2D != null){
                Vector2 direction = collision.transform.position - transform.position;
                float distance = 1 + direction.magnitude;
                float finalForece = burstForece / distance;
                rb2D.AddForce(direction * finalForece);
                
            }
        }
        Instantiate(burstEfect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    private void OnDrawGizmos(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radio);
    }

    
}
