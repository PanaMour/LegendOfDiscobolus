using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discus : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject gate;
    [SerializeField] private GameObject blocker1;
    [SerializeField] private GameObject blocker2;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.DiscusCollected();
            gameObject.SetActive(false);
            wall.SetActive(false);
            gate.SetActive(false);
            blocker1.GetComponent<NPCInteraction>().dialogue3 = true;
            blocker2.GetComponent<NPCInteraction>().dialogue2 = true;
        }
    }
}
