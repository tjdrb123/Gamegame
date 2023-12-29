using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform target;

    [Header("추격 속도")]
    [SerializeField][Range(1f, 4f)] private float moveSpeed = 3f;

    [Header("근접 거리")]
    [SerializeField][Range(0f, 3f)] private float contactDistance = 1f;

    private bool follow = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if (Vector2.Distance(transform.position, target.position) > contactDistance && follow)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        follow = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        follow = false;
    }
}
