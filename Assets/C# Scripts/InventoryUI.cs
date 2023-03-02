using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI tomatoText;
    private TextMeshProUGUI discusText;
    private TextMeshProUGUI keyText;
    // Start is called before the first frame update
    void Start()
    {
        tomatoText = GetComponent<TextMeshProUGUI>();
        discusText = GetComponent<TextMeshProUGUI>();
        keyText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateTomatoText(PlayerInventory playerInventory)
    {
        tomatoText.text = "x" + playerInventory.NumberOfTomatoes.ToString();
    }

    public void UpdateDiscusText(PlayerInventory playerInventory)
    {
        discusText.text = "x" + playerInventory.NumberOfDiscus.ToString();
    }
    public void UpdateKeyText(PlayerInventory playerInventory)
    {
        keyText.text = "x" + playerInventory.NumberOfKeys.ToString();
    }
}
