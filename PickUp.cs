using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{   [Header("References")]
    Inventory inventory;
    Collider coll;

    [Header("Variables")]
    public int Id;
    public Image sprite;
    
    void Start()
    {
        GetComponents();
    }
    void GetComponents()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        coll = gameObject.GetComponent<Collider>();
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                GetItem();
            }
        }
    }

    void GetItem() //player get iten in inventory
    {
        for (int i = 0; i < inventory.Slots.Length; i++)
        {
            if (!inventory.IsFull[i])
            {
                AddItem(i); 
                break;
            }
        }
    }
    void UpdateInventory() //update inventory when player drop or get itens
    {
        for (int i = 0; i < inventory.itens.Count; i++)
        {
            var itemIdCurrent = inventory.itens[i].transform.GetSiblingIndex(); //get position on hierarchy
            inventory.itens[i].GetComponent<PickUp>().Id = itemIdCurrent;

            if (inventory.IsFull[i] && inventory.itens[i] != null)
            {
                inventory.IsFull[i] = true; 
            }
            else
            {
                inventory.IsFull[i] = false;
            }
        }
       
    }

    void AddItem(int i) //add itens on transform player, inventory and add list and update 
    {
        UpdateInventory(); 

        Id = i;
        inventory.itens.Add(gameObject);
        Instantiate(sprite, inventory.itens_image.transform, false);

        foreach (var item in inventory.itens)
        {
            item.transform.position = inventory.collect.transform.position;
            item.transform.parent = inventory.collect.transform;
            item.SetActive(false);
        }

        inventory.ActiveItem();
        inventory.InvUpdate();
        inventory.IsFull[i] = true;
        coll.enabled = false;
    }
    


}