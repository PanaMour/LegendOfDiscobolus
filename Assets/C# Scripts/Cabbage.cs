using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabbage : MonoBehaviour
{
    [SerializeField] private AudioSource pickup;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.CabbageCollected();
            pickup.Play();
            gameObject.SetActive(false);
        }
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
