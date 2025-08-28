using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] NPCInfo nPCInfo;

    SpriteRenderer spriteRenderer;
    Rigidbody2D _rigidbody2D;
    BoxCollider2D boxCollider2D;

    private Vector2 currentTargetPos;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        spriteRenderer.sprite = nPCInfo.Sprite;
        _rigidbody2D.gravityScale = 0;

    }
    private void Start()
    {
        Patrol();
    }
    private void Update()
    {
        Stop();
    }
    public void Patrol()
    {
        MoveTargetPoint();



    }

    private void Stop()
    {
        //if()
        //{
        //    _rigidbody2D.velocity = Vector2.zero;

        //}

    }

    private void WaitTime(float time)
    {

    }

    private void MoveTargetPoint()
    {
        float moveSpeed = UnityEngine.Random.Range((float)nPCInfo.MinSpeed, nPCInfo.MaxSpeed); // using Random = UnityEngine.Random

        Vector2 randomPosition = (Vector2)transform.position + UnityEngine.Random.insideUnitCircle * nPCInfo.PatrolRadius;

        //Debug.Log(randomPosition);

        _rigidbody2D.velocity = (randomPosition - (Vector2)transform.position).normalized * moveSpeed;

    }
}
