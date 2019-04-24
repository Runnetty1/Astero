using InventorySystem.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CreateDropItem {

    public CreateDropItem()
    {

    }

    public CreateDropItem(List<GameObject> inventoryItems,Vector3 pos,bool useFirstAsSprite)
    {
        pos.z = 0;
        
        GameObject dropIt = Resources.Load<GameObject>("Assets/Resources/DropItem.prefab");

        if (useFirstAsSprite) {
            dropIt.GetComponent<SpriteRenderer>().sprite = inventoryItems[0].GetComponent<Image>().sprite;
        }
        dropIt.transform.position = pos;
        dropIt.GetComponent<DropedItem>().inventoryItems = inventoryItems;
    }
}
