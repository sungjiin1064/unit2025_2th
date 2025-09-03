using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    float moveSpeed = 5f;
    Vector2 move;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        move = new Vector2(moveX, moveY).normalized;
    }
    private void FixedUpdate()
    {
        _rigidbody2D.velocity = move * moveSpeed;
    }


}
