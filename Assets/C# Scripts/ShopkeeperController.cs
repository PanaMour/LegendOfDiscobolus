using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class ShopkeeperController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    private bool idle;
    public float dis = 5f;
    public Transform playerTransform;
    private Quaternion rotation;
    public GameObject oldman;
    public GameObject battleaxe;
    public GameObject wallaxe;
    private Camera mainCamera;
    public GameObject blocker;
    public GameObject inviswall;
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
        if (oldman.GetComponent<NPCInteraction>().showDialogue) {
            if(oldman.GetComponent<NPCInteraction>().dialogue2 == true && battleaxe.activeSelf == false)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == oldman)
                    {
                        battleaxe.SetActive(true);
                        blocker.GetComponent<NPCInteraction>().dialogue2= true;
                        inviswall.SetActive(false);
                        wallaxe.SetActive(false);
                        playerTransform.GetComponent<PlayerInventory>().NumberOfTomatoes = playerTransform.GetComponent<PlayerInventory>().NumberOfTomatoes - 6;
                        playerTransform.GetComponent<PlayerInventory>().TomatoCollected();
                    }
                }
            }
            else if(battleaxe.activeSelf)
            {
                oldman.GetComponent<NPCInteraction>().dialogue3 = true;
            }
        }
    }
}
