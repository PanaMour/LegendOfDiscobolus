using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if(playerInventory!= null)
        {
            playerInventory.TomatoCollected();
            gameObject.SetActive(false);
        }
    }
}
