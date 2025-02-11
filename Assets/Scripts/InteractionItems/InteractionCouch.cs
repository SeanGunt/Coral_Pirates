using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCouch : ItemInteractor
{
    public Sprite ffSprite;
    public override void Interact()
    {
        if (InventoryManager.instance.nameOfSelectedItem == "Item_FreakFish(Clone)")
        {
            GameObject FF = new();
            FF.transform.parent = transform;
            SpriteRenderer ffSpriteRenderer = FF.AddComponent<SpriteRenderer>();
            ffSpriteRenderer.sortingOrder = 1;
            ffSpriteRenderer.sprite = ffSprite;
            FF.transform.localPosition = Vector3.zero;
            foreach(var objective in QuestManager.instance.objectives)
            {
                if (objective.ContainsKey("FFPlaced"))
                {
                    objective["FFPlaced"] = true;
                }
            }
        }
    }
}
