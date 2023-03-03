using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonUIHover : MonoBehaviour
{
    [SerializeField] private TMP_FontAsset OldGlow;
    [SerializeField] private TMP_FontAsset OldNoGlow;
    public void OnPointerEnter()
    {
        this.transform.Find("Text").GetComponent<TextMeshProUGUI>().font = OldGlow;
    }

    public void OnPointerExit()
    {
        this.transform.Find("Text").GetComponent<TextMeshProUGUI>().font = OldNoGlow;
    }
}
