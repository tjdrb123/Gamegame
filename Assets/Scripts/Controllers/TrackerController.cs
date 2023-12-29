using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrackerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform target;

    [Header("�߰� �ӵ�")]
    [SerializeField][Range(1f, 9f)] private float moveSpeed = 6f;

    [Header("���� �Ÿ�")]
    [SerializeField][Range(0f, 3f)] private float contactDistance = 1f;

    private bool follow = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void FixedUpdate()
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
        if (collision.gameObject.tag == "Player")
        {
            follow = true;
            Debug.Log("true");
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            follow = false;
            Debug.Log("false");
        }
     
    }
}
