using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfTomatoes;
    public int NumberOfDiscus;
    public UnityEvent<PlayerInventory> OnTomatoCollected;
    public UnityEvent<PlayerInventory> OnDiscusCollected;
    public Canvas canvas;
    public Canvas discusCanvas;
    private bool invisible = true;
    private bool invisibleDiscus = true;
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
    public void DiscusCollected()
    {
        invisibleDiscus = false;
        NumberOfDiscus++;
        OnDiscusCollected.Invoke(this);
        StartCoroutine(InvisibleCanvas());
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

        if (invisibleDiscus)
        {
            discusCanvas.gameObject.SetActive(false);
        }
        else
        {
            discusCanvas.gameObject.SetActive(true);
        }
    }

    IEnumerator InvisibleCanvas()
    {
        yield return new WaitForSeconds(10);
        invisible= true;
        invisibleDiscus = true;
    }
}
