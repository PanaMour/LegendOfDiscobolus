using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_FontAsset OldGlow;
    [SerializeField] private TMP_FontAsset OldNoGlow;
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
        Debug.Log("CONTROLS");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OnPointerEnter()
    {
        Debug.Log(this.transform.Find("Text").GetComponent<TextMeshProUGUI>().font);
        this.transform.Find("Text").GetComponent<TextMeshProUGUI>().font = OldGlow;
    }

    public void OnPointerExit()
    {
        Debug.Log(this.transform.Find("Text").GetComponent<TextMeshProUGUI>().font + "EXIT");
        this.transform.Find("Text").GetComponent<TextMeshProUGUI>().font = OldNoGlow;
    }
}
