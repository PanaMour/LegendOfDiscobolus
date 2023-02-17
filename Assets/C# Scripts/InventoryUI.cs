using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI tomatoText;
    // Start is called before the first frame update
    void Start()
    {
        tomatoText= GetComponent<TextMeshProUGUI>();
    }

    public void UpdateTomatoText(PlayerInventory playerInventory)
    {
        tomatoText.text = "x" + playerInventory.NumberOfTomatoes.ToString();
    }
}
