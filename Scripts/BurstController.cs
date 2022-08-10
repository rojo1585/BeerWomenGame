using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstController : MonoBehaviour
{
    // Start is called before the first frame update
    private void DestroyThis(){
        Destroy(gameObject);
    }
}
