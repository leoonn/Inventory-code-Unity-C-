using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("References")]
    public GameObject[] Slots;
    public GameObject itens_image;
    public GameObject InventoryUI;
    public GameObject itemSelected;
    public Transform collect;
    [Header("variables")]
    public bool[] IsFull;
    public int totalItem;
    public List<GameObject> itens = new List<GameObject>();
    
    private void Start()
    {
        GetComponents();
    }
    private void GetComponents()
    {
        collect = GameObject.Find("Collect").GetComponent<Transform>();
        totalItem = Slots.Length; // limita quantos itens pode entrar no inventario
    }
    void Update()
    {
        
        OpenInventory();
        ReturnItemActive();
    }

    void OpenInventory() 
    {
        if (Input.GetKey(KeyCode.I))
        {
            InventoryUI.SetActive(true);
        }
        else
        {
            InventoryUI.SetActive(false);
        }
    }
    void ReturnItemActive() //Return item ative in player
    {
        foreach (GameObject item in itens)
        {
            if (item.activeInHierarchy)
            {
                // Debug.Log(item);
                itemSelected = item;
            }

        }

    }
    public void InvUpdate(){ //inventory Update
        
        for (int i = 0; i < itens.Count; i++)
            {
                IsFull[i] = true;
                itens[i].GetComponent<PickUp>().Id = i;
                // Debug.Log("[INV]  " + i);
            }
    }
    
    public void ActiveItem() //Check if item is active, if not active slot 0
    {
        for (int i = 0; i < itens.Count; i++)
        {
            
            if (!itens[i].activeInHierarchy) 
            {
              
                itens[0].SetActive(true);
            }
        }

    }

}

