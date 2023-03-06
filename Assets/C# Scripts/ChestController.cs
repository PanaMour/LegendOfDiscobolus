using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class ChestController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    private Camera mainCamera;
    public GameObject chest;
    public GameObject scroll;
    public GameObject player;
    private bool isOpen = false;
    public string dialogueText = "";
    public bool showDialogue = false;
    public float x = Screen.width / 2 - 100;
    public float y = Screen.height / 2 - 50;
    public float width = 100;
    public float height = 50;
    public bool isStopping = true;
    public int timeofDialogue = 5;
    public AudioSource audioSound;
    public GameObject pauseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        chest = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && player.GetComponent<PlayerInventory>().NumberOfKeys >= 1 && !isOpen)
        {
            Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == chest)
                {
                    audioSound.Play();
                    animator.Play("Animated PBR Chest _Idle");                    
                    isOpen = true;
                    StartCoroutine(ScrollWait());
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == chest)
                {
                    showDialogue = true;

                    if (isStopping)
                    {
                        isStopping = false;
                        StartCoroutine(StopShowing());
                    }
                }
                else
                    showDialogue = false;
            }
        }
    }
    private void OnGUI()
    {
        if (showDialogue && !pauseCanvas.activeSelf)
        {
            x = 25;
            height = 70;
            width = Screen.width - 2 * x;
            y = Screen.height - height - 10;
            Rect dialogueBox = new Rect(x, y, width, height);
            var boldtext = new GUIStyle(GUI.skin.label);
            boldtext.fontStyle = FontStyle.Bold;
            boldtext.fontSize = 25;
            GUIStyle dialogueStyle = new GUIStyle(GUI.skin.box);
            dialogueStyle.normal.textColor = Color.white;
            dialogueStyle.fontStyle = FontStyle.Bold;
            GUILayout.BeginArea(dialogueBox);
            GUI.Label(new Rect(20, 17, width, height), "Chest", boldtext);
            GUI.Box(new Rect(0, 0, width, height), dialogueText.Replace("\\n", "\n"), dialogueStyle);
            GUILayout.EndArea();
        }
    }
    IEnumerator StopShowing()
    {
        yield return new WaitForSeconds(timeofDialogue);
        showDialogue = false;
        isStopping = true;
    }

    IEnumerator ScrollWait()
    {
        yield return new WaitForSeconds(3);
        scroll.SetActive(true);
    }
}
