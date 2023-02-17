using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfTomatoes { get; private set; }
    public UnityEvent<PlayerInventory> OnTomatoCollected;
    public Canvas canvas;
    private bool invisible = true;

    public void TomatoCollected()
    {
        invisible= false;
        NumberOfTomatoes++;
        OnTomatoCollected.Invoke(this);
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
    }

    IEnumerator InvisibleCanvas()
    {
        yield return new WaitForSeconds(10);
        invisible= true;
    }
}
