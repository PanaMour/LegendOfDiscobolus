using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class OldManController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    private bool idle;
    public float dis = 5f;
    public Transform playerTransform;
    private Quaternion rotation;
    public GameObject oldman;
    public GameObject cabbage;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        rotation = transform.rotation;
        idle = true;
        oldman = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        idle = this.gameObject.GetComponent<NPCInteraction>().isStopping;
        if (idle)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3.0f);
            animator.Play("Idle");
        }
        else
        {
            transform.LookAt(new Vector3(playerTransform.position.x, this.gameObject.transform.position.y, playerTransform.position.z));
            animator.Play("Scratch");
        }
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (oldman.GetComponent<NPCInteraction>().showDialogue)
        {
            if (oldman.GetComponent<NPCInteraction>().dialogue2 == true)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == oldman && playerTransform.GetComponent<PlayerInventory>().NumberOfCabbages > 0)
                    {
                        playerTransform.GetComponent<PlayerInventory>().NumberOfCabbages = playerTransform.GetComponent<PlayerInventory>().NumberOfCabbages - 2;
                        playerTransform.GetComponent<PlayerInventory>().CabbageCollected();
                    }
                }
            }
            else
            {
                cabbage.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
}
