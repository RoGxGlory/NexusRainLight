using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int weight, value;

    public GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
     //   manager = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }

    public void CollectMoney()
    {
        manager.UpdateMoney(value);
    }

    
}
