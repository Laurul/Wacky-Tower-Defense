using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using UnityEngine.XR;

public class Inventory : MonoBehaviour
{
   // [SerializeField] List<GameObject> _weapons;
    [SerializeField] List<GameObject> _itemHolders;
    [SerializeField] OVRInput.Button ToggleInventory;
    [SerializeField] OVRInput.Button changeToNextItemInInventory;
    [SerializeField] OVRInput.Button selectItemFromInventory;
    int indexOfItem = 0;
    int index = 0;
    DistanceGrabbable o;
    [SerializeField] DistanceGrabber hand;
   List< GameObject> items;
    bool canAdd = true;
    bool itemToinventory = true;

    bool inventoryOpen = false;

    // Start is called before the first frame update
    void Start()

    {
        items = new List<GameObject>();
        //hand.transform.position += new Vector3(0, 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(ToggleInventory))
        {
            
            inventoryOpen = !inventoryOpen;
        }

        if (inventoryOpen == true)
        {
            if (OVRInput.GetDown(changeToNextItemInInventory))
            {
                indexOfItem++;
                if (indexOfItem >= items.Count)
                {
                    indexOfItem = 0;
                }
            }
            if (OVRInput.GetDown(selectItemFromInventory))
            {
                
                items[indexOfItem].transform.position=hand.transform.position;
                items.RemoveAt(indexOfItem);
            }
        }
        //if(handToInventory == 1)
        //{
        //    if (index >= items.Count)
        //    {
        //        index = 0;
        //    }

        //    items[index].transform.position = d.transform.position;

        //    if (index > 0)
        //    {
        //        items[index-1].transform.position = _itemHolders[0].transform.position;
        //    }
        //    index++;
        //}

        //if(handToInventory==2)

        //if (handToInventory > 2)
        //{
        //    handToInventory = 0;
        //}
       
       // Debug.Log(d.grabbedObject);
        if (hand.grabbedObject != null)
        {
            if (hand.grabbedObject.tag == "weapon"&&canAdd==true)
            { 
                foreach(GameObject g in items)
                {
                    if (hand.grabbedObject.name == g.name)
                    {
                        itemToinventory = false;
                    }
                }

                if (itemToinventory == true)
                {
                    items.Add(hand.grabbedObject.gameObject);
                }
                

            }
        }
        itemToinventory = true;



        foreach(GameObject g in items)
        {
           
            if (g.GetComponent<DistanceGrabbable>().isGrabbed==false)
            {
                
                AddObjectToInventory(g);
               
            }
        }



        void AddObjectToInventory(GameObject g){
            
                    g.transform.position = _itemHolders[0].transform.position;
             
        }
         
      
    }

    //private void OnGUI()
    //{
    //    if (inventoryOpen == true)
    //    {
    //        GUILayout.TextArea("Inventory is open");
    //    }
    //   if (inventoryOpen == false)
    //    {
    //        GUILayout.TextArea("Inventory is closed");
    //    }
       
    //}
    public bool ReturnInventoryOpen()
    {
        return inventoryOpen;
    }
    public string NameOfCurrentItem()
    {
        return items[indexOfItem].name;
    }
    public int InventoryCount()
    {
        return items.Count;
    }
}
