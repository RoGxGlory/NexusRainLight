using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlShip : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int totalValue, totalWeight, maxWeight;
    [SerializeField] public List<GameObject> shipInventory;

    void Start()
    {
        totalValue = 0;
        totalWeight = 0; 
        maxWeight = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            GetInventory(collision.transform.GetComponent<Player>().inventory);
        }
 
    }

    public void GetInventory(List<GameObject> inventory)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            shipInventory.Add(inventory[i]);

            totalValue += shipInventory[i].GetComponent<Collectible>().value;
            totalWeight += shipInventory[i].GetComponent<Collectible>().weight;
        }
        inventory.Clear();
        Debug.Log("Total value: " + totalValue + "; Weight: " + totalWeight);

        if (totalWeight > maxWeight)
        {
            Debug.LogError("Player is gros");
            // Player is overweight
            // Implement player overweight behavior
        }
    }
}

/*

C:\Users\mehdi\Documents\UnityProject\UnityGit\NexusRainLight\Assets\00_Script\Interact\LvlShip.cs*/