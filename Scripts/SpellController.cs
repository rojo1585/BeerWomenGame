using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{

    private Animator animator;
    private GameObject Player;
    [SerializeField] private BoxCollider2D spellCollider;

    [SerializeField] private float offsetBoxCollider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Player = GameObject.Find("Player");
        spellCollider = spellCollider.GetComponent<BoxCollider2D>();
        offsetBoxCollider = 0.02f;

    }

    // Update is called once per frame
    void Update()
    {   
        
            ChangeZize();
        
    }

    private void ChangeZize(){
        spellCollider.size = new Vector3(0.1421051f,0.4182262f);
    }
}
