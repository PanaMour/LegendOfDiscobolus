using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private AudioSource pickup;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.KeyCollected();
            pickup.Play();
            gameObject.SetActive(false);
        }
    }
}
