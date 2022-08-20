using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoinController : MonoBehaviour
{
    // Start is called before the first frame update
    public SpikeController SpikeController;

    void Start()
    {
        SpikeController = GameObject.Find("Spikes").GetComponent<SpikeController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(){
        SpikeController.FallSpike();
        Destroy(gameObject);
    }
}
