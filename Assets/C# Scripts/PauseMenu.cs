using StarterAssets;
using System.Collections;
using System.Collections.Generic;
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
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !panel.activeSelf)
        {
            audioSources = GameObject.FindObjectsOfType<AudioSource>(true);
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseCanvas.SetActive(isPaused);
            mainCamera.GetComponent<CursorVisible>().enabled = isPaused;
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
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        mainCamera.GetComponent<CursorVisible>().enabled = false;
        player.GetComponent<ThirdPersonController>().LockCameraPosition = false;
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.UnPause();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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
}
