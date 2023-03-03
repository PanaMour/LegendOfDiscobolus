using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class FinalScene : MonoBehaviour
{
    [SerializeField] private GameObject mainmenu;
    [SerializeField] private GameObject exit;
    [SerializeField] private VideoPlayer player;
    [SerializeField] private AudioSource unfold;
    void Start()
    {
        player.Play();
        StartCoroutine(Unfold());
        StartCoroutine(ButtonAppear());
    }
    void Update()
    {
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
    IEnumerator ButtonAppear()
    {
        yield return new WaitForSeconds(12);
        mainmenu.SetActive(true);
        exit.SetActive(true);
    }
    IEnumerator Unfold()
    {
        yield return new WaitForSeconds(1);
        unfold.Play();
    }
}
