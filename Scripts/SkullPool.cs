using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullPool : MonoBehaviour
{
    [SerializeField] private GameObject prefabSkull;
    private int poolSize;
    [SerializeField] private List<GameObject> skullList;

    private static SkullPool instance;
    public static SkullPool Instance { get {return instance;}}
    private void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        poolSize = 5;
        AddSkullToPool(poolSize);
        
    }

    private void  AddSkullToPool(int amount){
       for(int i = 0; i < poolSize; i++){
            GameObject skull = Instantiate(prefabSkull);
            skull.SetActive(false);
            skullList.Add(skull);
            skull.transform.parent = transform;
        }
    }

    public GameObject RequestSkull(){
        for(int i = 0; i < skullList.Count; i++){
            if(!skullList[i].activeSelf){
                skullList[i].SetActive(true);
                return skullList[i];
            }
        }
        AddSkullToPool(1);
        skullList[skullList.Count -1].SetActive(true);
        return skullList[skullList.Count - 1];
    }

    
}
