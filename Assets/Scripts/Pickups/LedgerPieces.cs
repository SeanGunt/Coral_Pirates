using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LedgerPieces : Pickup
{
    protected override void AddToInventory()
    {
        InventoryItem inventoryItem = InventoryManager.instance.AddItemToInventory();
        if (inventoryItem != null && !itemAdded)
        {
            Image image = inventoryItem.gameObject.GetComponent<Image>();
            Instantiate(itemToAdd, inventoryItem.transform);
            image.sprite = itemSprite;
            image.color = Color.white;
            itemAdded = true;
            if (Utility.instance.GetListOfObjectsByScriptType("LedgerPieces").Count - 1 == 0)
            {
                Debug.Log("Collected All Pieces");
                foreach(var objective in QuestManager.instance.objectives)
                {
                    if (objective.ContainsKey("LedgerPiecesFound"))
                    {
                        objective["LedgerPiecesFound"] = true;
                    }
                }
            }
            else
            {
                Debug.Log("Still have more to collect");
            }
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
