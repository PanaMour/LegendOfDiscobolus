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
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        rotation = transform.rotation;
        idle = true;
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
    }
}
