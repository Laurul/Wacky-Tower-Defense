using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHelpText : MonoBehaviour
{
    [SerializeField] Inventory inv;
    [SerializeField] List<Text> displayAllText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inv.ReturnInventoryOpen()==true)
        {
            displayAllText[0].text = "Inventory is open";
        }
        if (inv.ReturnInventoryOpen()==false)
        {
            displayAllText[0].text = "Inventory is closed";
        }
        if (inv.InventoryCount() == 0)
        {
            displayAllText[1].text = "Inventory has no items";
        }
        else
        {
            displayAllText[1].text = inv.NameOfCurrentItem();
        }
       
    }
}
