using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    [SerializeField] private AudioSource pickup;
    public GameObject player;
    public int HP = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<PlayerHealth>().Heal(HP);
            pickup.Play();
            gameObject.SetActive(false);
        }
    }
}
