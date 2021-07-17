using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler
{
    [Header("References")]
    Inventory inventory;

    private void Start()
    {
        GetComponents();
    }

    private void GetComponents()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }


    public void OnDrag(PointerEventData eventData) //drag item
    {
        inventory.InventoryUI.transform.GetChild(1).GetComponent<UnityEngine.UI.GridLayoutGroup>().enabled = false;
        gameObject.transform.position = Input.mousePosition;
        Debug.Log("[INV] OnDRAG");
    }




    public void OnDrop(PointerEventData eventData) //Drop
    { 
        gameObject.transform.localPosition = Vector3.zero;
        inventory.InventoryUI.transform.GetChild(1).GetComponent<UnityEngine.UI.GridLayoutGroup>().enabled = true; //disable grid 

        RectTransform InvSlots = inventory.InventoryUI.transform as RectTransform; //check if draged object is off panels
        if (!RectTransformUtility.RectangleContainsScreenPoint(InvSlots, Input.mousePosition))
        {
            GetComponent<SpawitemInventory>().SpawDropItem();
            var itemIdCurrent = transform.GetSiblingIndex();
            Destroy(inventory.collect.GetChild(itemIdCurrent).gameObject);
            Destroy(gameObject);
            inventory.itens.RemoveAt(itemIdCurrent);
            inventory.IsFull[itemIdCurrent] = false;

            // update inventory after drop
            for (int i = 0; i < inventory.IsFull.Length; i++)
            {
                inventory.IsFull[i] = false;
            }
            inventory.ActiveItem();
            Debug.Log("[INV]  DROP");
            inventory.InvUpdate();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        inventory.InvUpdate(); //atualiza inventario
        Debug.Log("[INV]  Enddrag");
    }

    public void OnPointerClick(PointerEventData eventData) // seleçao de itens
    {
        var id = eventData.pointerEnter.transform.GetSiblingIndex();

        if (id >= 0)
        {
            if (inventory.itens[id].GetComponent<PickUp>().Id == id)
            {
                for (int i = 0; i < inventory.collect.transform.childCount; i++)
                {
                    inventory.itens[i].SetActive(false);
                }
                inventory.itens[id].SetActive(true);
            }
        }

    }
}
