using InventorySystem.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropedItem : MonoBehaviour {

    public List<GameObject> inventoryItems;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            //Spawn 
            foreach (GameObject g in inventoryItems)
            {
                GameObject gg = Instantiate(g, Vector3.zero, Quaternion.identity);
                Item ite = gg.GetComponent<Item>();
                //collision.GetComponent<Player>().inventory.AddItem(ite);
            }
            Destroy(this.gameObject);
        }
    }
}
