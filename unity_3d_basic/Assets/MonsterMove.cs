using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] public float moveSpeed = 5f;
    private Vector2 targetVector;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        targetVector = SetPositionToCenter();

        _rigidbody2D.velocity = targetVector.normalized * moveSpeed;
    }

    private Vector2 SetPositionToCenter()
    {
        return Vector2.zero - (Vector2)transform.position;
    }

}
