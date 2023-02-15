using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public string dialogueText = "";
    private bool showDialogue = false;
    public float x = Screen.width / 2 - 100;
    public float y = Screen.height / 2 - 50;
    public float width = 100;
    public float height = 50;
    private Camera mainCamera;
    public bool isStopping = true;
    public GameObject npc;
    public int timeofDialogue = 5;

    void Start()
    {
        mainCamera = Camera.main;
        npc = this.gameObject;
        //dialogueText = this.gameObject.GetComponent<NPCInteraction>().dialogueText;
    }
    private void OnGUI()
    {
        if (showDialogue)
        {
            Rect dialogueBox = new Rect(x, y, width, height);
            var boldtext = new GUIStyle(GUI.skin.label);
            boldtext.fontStyle = FontStyle.Bold;
            boldtext.fontSize = 25;
            GUIStyle dialogueStyle = new GUIStyle(GUI.skin.box);
            dialogueStyle.normal.textColor = Color.white;
            dialogueStyle.fontStyle = FontStyle.Bold;
            string npcName = npc.name;
            GUILayout.BeginArea(dialogueBox);
            GUI.Label(new Rect(20, 8, 1100, 50), npcName, boldtext);
            GUI.Box(new Rect(0, 0, 1100, 50), dialogueText.Replace("\\n", "\n"), dialogueStyle);
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
                    if (isStopping)
                    {
                        isStopping = false;
                        StartCoroutine(StopShowing());
                    }
                }
            }
        }
    }

    IEnumerator StopShowing()
    {
        yield return new WaitForSeconds(timeofDialogue);
        showDialogue = false;
        isStopping = true;
    }
}
