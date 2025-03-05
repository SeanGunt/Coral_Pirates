using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionLedger : ItemInteractor
{
   public override void Interact()
   { 
        if (InventoryManager.instance.nameOfSelectedItem == "Item_LedgerPiece1(Clone)")
        {
            foreach(var objective in QuestManager.instance.objectives)
            {
                if (objective.ContainsKey("LedgerFound"))
                {
                    objective["LedgerFound"] = true;
                }
            }
        } 
    
    
   }
}
