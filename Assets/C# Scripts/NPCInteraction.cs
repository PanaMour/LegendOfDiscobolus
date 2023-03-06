using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public List<string> dialogueOptions = new List<string>();
    public string dialogueText = "";
    public bool showDialogue = false;
    public float x = Screen.width / 2 - 100;
    public float y = Screen.height / 2 - 50;
    public float width = 100;
    public float height = 50;
    private Camera mainCamera;
    public bool isStopping = true;
    public GameObject npc;
    public int timeofDialogue = 5;
    public bool dialogue2 = false;
    public bool dialogue3 = false;
    public AudioSource audioSound;

    void Start()
    {
        mainCamera = Camera.main;
        npc = this.gameObject;
    }
    private void OnGUI()
    {
        if (showDialogue)
        {
            x = 25;
            height = 70;
            width = Screen.width-2*x;
            y = Screen.height - height-10;
            Rect dialogueBox = new Rect(x, y, width, height);
            var boldtext = new GUIStyle(GUI.skin.label);
            boldtext.fontStyle = FontStyle.Bold;
            boldtext.fontSize = 25;
            GUIStyle dialogueStyle = new GUIStyle(GUI.skin.box);
            dialogueStyle.normal.textColor = Color.white;
            dialogueStyle.fontStyle = FontStyle.Bold;
            string npcName = npc.name;
            GUILayout.BeginArea(dialogueBox);
            GUI.Label(new Rect(20, 17, width, height), npcName, boldtext);
            GUI.Box(new Rect(0, 0, width, height), dialogueText.Replace("\\n", "\n"), dialogueStyle);
            GUILayout.EndArea();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == npc)
                {
                    showDialogue = true;
                    
                    if (dialogueOptions != null && dialogueOptions.Count != 0)
                    {
                        if (dialogue3)
                        {
                            dialogueText = dialogueOptions[2];
                        }
                        else if (dialogue2)
                        {
                            dialogueText = dialogueOptions[1];
                        }
                        else
                        {
                            dialogueText = dialogueOptions[0];
                        }
                    }
                    
                    if (isStopping)
                    {
                        isStopping = false;
                        StartCoroutine(StopShowing());
                    }
                }
                else
                    showDialogue= false;
            }
        }
    }

    IEnumerator StopShowing()
    {
        if (audioSound != null)
        {
            audioSound.Play();
        }
        yield return new WaitForSeconds(timeofDialogue);
        showDialogue = false;
        isStopping = true;
    }
}
