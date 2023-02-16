using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class BlockerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    private bool idle;
    public float dis = 5f;
    public Transform playerTransform;
    Vector3 newRotation = new Vector3(0f, 100.752f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        idle = true;
    }

    // Update is called once per frame
    void Update()
    {
        idle = this.gameObject.GetComponent<NPCInteraction>().isStopping;
        if (idle)
        {
            transform.rotation = Quaternion.Euler(newRotation);
            animator.Play("Sitting");
        }
        else
        {
            transform.LookAt(playerTransform);
            animator.Play("Disapprove");
        }
    }
}
