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
    [SerializeField] private GameObject fakebg;
    [SerializeField] private GameObject exit;
    [SerializeField] private GameObject difficulty;
    [SerializeField] private GameObject loading;
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
        difficulty.SetActive(true);
        fakebg.SetActive(true);
    }
    
    public void Easy()
    {
        loading.SetActive(true);
        GameManager.instance.currentDifficulty = GameManager.DifficultyLevel.Easy;
        difficulty.SetActive(false);
        fakebg.SetActive(false);
    }
    public void Medium()
    {
        loading.SetActive(true);
        GameManager.instance.currentDifficulty = GameManager.DifficultyLevel.Medium;
        difficulty.SetActive(false);
        fakebg.SetActive(false);
    }
    public void Hard()
    {
        loading.SetActive(true);
        GameManager.instance.currentDifficulty = GameManager.DifficultyLevel.Hard;
        difficulty.SetActive(false);
        fakebg.SetActive(false);
    }
    public void Impossible()
    {
        loading.SetActive(true);
        GameManager.instance.currentDifficulty = GameManager.DifficultyLevel.Impossible;
        difficulty.SetActive(false);
        fakebg.SetActive(false);
    }
    public void X()
    {
        difficulty.SetActive(false);
        fakebg.SetActive(false);
    }
    public void Controls()
    {
        panel.SetActive(true);
    }

    public void Exit()
    {
        exit.SetActive(true);
        fakebg.SetActive(true);
    }

    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        exit.SetActive(false);
        fakebg.SetActive(false);
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
