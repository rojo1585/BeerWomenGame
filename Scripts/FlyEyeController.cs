using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEyeController : MonoBehaviour
{
    
    public GameObject Player;
    PlayerController playerController;
    
    [SerializeField] private float speed;
    [SerializeField] private float distancePlayer;
    [SerializeField] private float rangeVision;

    Vector3 direction;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Player.transform.position - transform.position;
        distancePlayer = Vector2.Distance(transform.position,Player.transform.position);

        if(distancePlayer <  rangeVision && Mathf.Abs(distancePlayer) > 0.2f) {
            GetComponent<EnemyController>().Run();
            GetComponent<EnemyController>().FollowPlayer(speed,direction);
            
        }else{
            GetComponent<EnemyController>().DontFollowPlayer(direction);
            GetComponent<EnemyController>().NoRun();

        }
        
    }

    
}
