using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullController : MonoBehaviour
{

    [SerializeField] private Transform player;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
     // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnSkull(Vector3 target){
        if(transform.position.x < target.x){spriteRenderer.flipX = true;}else{spriteRenderer.flipX = false;}
    }
}
