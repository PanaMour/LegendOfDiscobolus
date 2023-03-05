using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_FontAsset OldGlow;
    [SerializeField] private TMP_FontAsset OldNoGlow;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject exit
        ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Controls()
    {
        panel.SetActive(true);
    }

    public void Exit()
    {
        exit.SetActive(true);
    }

    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        exit.SetActive(false);
    }

    public void OnPointerEnter()
    {
        this.transform.Find("Text").GetComponent<TextMeshProUGUI>().font = OldGlow;
    }

    public void OnPointerExit()
    {
        this.transform.Find("Text").GetComponent<TextMeshProUGUI>().font = OldNoGlow;
    }
}
