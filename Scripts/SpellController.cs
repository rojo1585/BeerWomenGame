using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{

    private Animator animator;
    private GameObject Player;
    [SerializeField] private BoxCollider2D spellCollider;

    [SerializeField] private float offsetBoxCollider;
    [SerializeField] private float damage;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Player = GameObject.Find("Player");
        spellCollider = spellCollider.GetComponent<BoxCollider2D>();
        offsetBoxCollider = 0.02f;
        damage = 50.0f;
    }

    // Update is called once per frame
    void Update()
    {   
        
       
        
    }
    private void DestroySpell(){
        Destroy(gameObject);
    }
    private void ChangeZize(){
        spellCollider.size = new Vector3(0.2292644f,.6018996f);
        spellCollider.offset = new Vector3(-0.01104566f, -0.2209671f);
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            collision.GetComponent<PlayerController>().TakeDamagePlayer(damage);
        }
    }
}
