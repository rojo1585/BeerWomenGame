using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] private Transform skullSpawn;
    [SerializeField] private GameObject skull;
    [SerializeField] private float timeToSpawn;
    [SerializeField] private float timeBetweenSpawn;
    //s Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawn -= Time.deltaTime;
        if(timeToSpawn <= 0){
            Instantiate(skull, skullSpawn.position, Quaternion.identity);
            timeToSpawn =  timeBetweenSpawn; 
        }
        
    }
}
