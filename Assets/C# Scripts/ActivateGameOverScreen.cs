using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameOverScreen : MonoBehaviour
{
    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ActivateGameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
