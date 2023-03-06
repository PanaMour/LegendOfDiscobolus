using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    [SerializeField] private AudioSource pickup;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if(playerInventory!= null)
        {
            playerInventory.TomatoCollected();
            pickup.Play();
            gameObject.SetActive(false);
        }
    }
}
