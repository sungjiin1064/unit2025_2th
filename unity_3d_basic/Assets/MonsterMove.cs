using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] float moveSpeed = 3f;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        Vector2 direction = (Vector2.zero - rigidbody2D.position).normalized;
    }
    private void FixedUpdate()
    {
        Vector2 direction = (Vector2.zero - rigidbody2D.position).normalized;

        rigidbody2D.velocity = direction * moveSpeed;

    }
}
