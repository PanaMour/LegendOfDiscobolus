using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject pauseCanvas;
    private bool isPaused = false;
    [SerializeField] private GameObject player;
    private AudioSource[] audioSources;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject exit;
    [SerializeField] private GameObject exitMain;
    [SerializeField] private TextMeshProUGUI tomatoText;
    [SerializeField] private TextMeshProUGUI discusText;
    [SerializeField] private TextMeshProUGUI keyText;
    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !panel.activeSelf)
        {
            Cursor.visible = !isPaused;
            tomatoText.text = "x" + player.GetComponent<PlayerInventory>().NumberOfTomatoes.ToString();
            discusText.text = "x" + player.GetComponent<PlayerInventory>().NumberOfDiscus.ToString();
            keyText.text = "x" + player.GetComponent<PlayerInventory>().NumberOfKeys.ToString();
            audioSources = GameObject.FindObjectsOfType<AudioSource>(true);
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseCanvas.SetActive(isPaused);
            mainCamera.GetComponent<CursorVisible>().enabled = isPaused;
            mainCamera.GetComponent<CursorConfined>().enabled = !isPaused;
            player.GetComponent<ThirdPersonController>().LockCameraPosition = isPaused;
            foreach (AudioSource audioSource in audioSources)
            {
                if (isPaused)
                {
                    audioSource.Pause();
                }
                else
                {
                    audioSource.UnPause();
                }
            }
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        isPaused = !isPaused;
        mainCamera.GetComponent<CursorVisible>().enabled = false;
        mainCamera.GetComponent<CursorConfined>().enabled = true;
        player.GetComponent<ThirdPersonController>().LockCameraPosition = false;
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.UnPause();
        }
    }

    public void MainMenu()
    {
        exitMain.SetActive(true);
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
    public void YesMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void NoMain()
    {
        exitMain.SetActive(false);
    }
}
