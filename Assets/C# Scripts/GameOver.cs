using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject battleMusic;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.GetComponent<CursorVisible>().enabled= true;
        mainCamera.GetComponent<CursorConfined>().enabled = false;
        Time.timeScale = 0f;
        battleMusic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
