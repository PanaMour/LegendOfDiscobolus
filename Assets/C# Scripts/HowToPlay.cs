using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HowToPlay : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && panel.activeSelf)
        {
            panel.SetActive(false);
        }
    }

    public void OnPointerClick()
    {
        panel.SetActive(false);
    }
}
