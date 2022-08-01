using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpyBeerController : MonoBehaviour
{   
     [SerializeField] private float timeToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        timeToDestroy = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if(timeToDestroy <= 0 ){Destroy(gameObject);}
       
    }
}
