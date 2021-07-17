using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [Header("References")]
    public GameObject ItensPrefab;
    Transform player;


    private void Start()
    {
        GetComponents();
    }
    private void GetComponents()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void SpawDropItem()  //instantiate prefab
    {
        Vector3 playerpos = new Vector3(player.position.x, player.position.y, player.position.z);
        GameObject Rename = Instantiate(ItensPrefab, playerpos, Quaternion.identity);
        Rename.name = Item.name;
    }

}

