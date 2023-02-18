using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfTomatoes;
    public UnityEvent<PlayerInventory> OnTomatoCollected;
    public Canvas canvas;
    private bool invisible = true;
    public GameObject oldman;

    public void TomatoCollected()
    {
        invisible= false;
        NumberOfTomatoes++;
        OnTomatoCollected.Invoke(this);
        StartCoroutine(InvisibleCanvas());
        if (NumberOfTomatoes >= 5)
        {
            oldman.gameObject.GetComponent<NPCInteraction>().dialogue2= true;
        }
    }
    public void Update()
    {
        if (invisible)
        {
            canvas.gameObject.SetActive(false);
        }
        else
        {
            canvas.gameObject.SetActive(true);
        }
    }

    IEnumerator InvisibleCanvas()
    {
        yield return new WaitForSeconds(10);
        invisible= true;
    }
}
