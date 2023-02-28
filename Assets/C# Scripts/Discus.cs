using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discus : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.DiscusCollected();
            gameObject.SetActive(false);
            wall.SetActive(false);
        }
    }
}
