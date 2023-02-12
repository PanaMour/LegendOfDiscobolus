using UnityEngine;
using System.Collections;



public class RabbitHopper : MonoBehaviour
{
    private Animator animator;
    private Vector3 startPos;
    public float dis = 5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        startPos = transform.position;
    }

    private void Update()
    {
        animator.Play("Run");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, Time.deltaTime * 2.5f);

        if (Vector3.Distance(transform.position, startPos) >= dis)
        {
            animator.Play("Idle");
            transform.rotation = Quaternion.Euler(0f, 90f, 0f) * transform.rotation;
            startPos = transform.position;
        }

    }
}