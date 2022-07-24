using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{   
    public GameObject Player;
    private int healt = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyBox(){
        Destroy(gameObject);
    }
    private void OnCollisionEneter2D(Collision2D collision){
        DestroyBox();
    }
}
