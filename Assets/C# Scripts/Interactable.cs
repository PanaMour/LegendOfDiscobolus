using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public GameObject interactionCanvas;

    private bool inRange;

    private void Start()
    {
        // Disable the interaction canvas by default
        interactionCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactionCanvas.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the trigger
        if (other.CompareTag("Player"))
        {
            inRange = true;
            interactionCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player has exited the trigger
        if (other.CompareTag("Player"))
        {
            inRange = false;
            interactionCanvas.SetActive(false);
        }
    }
}
