using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject battleMusic;
    [SerializeField] private GameObject exit;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.GetComponent<CursorVisible>().enabled= true;
        Time.timeScale = 0f;
        battleMusic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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
}
