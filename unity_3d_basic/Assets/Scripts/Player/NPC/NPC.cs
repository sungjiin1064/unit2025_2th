using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollisionEvent
{
    Friendly, UnFriendly, UnDefined
}

public class NPC : MonoBehaviour
{
    [SerializeField] public NPCInfo nPCInfo;
    [SerializeField] CollisionEvent collisionEvent = CollisionEvent.UnDefined;

    SpriteRenderer spriteRenderer;
    Rigidbody2D _rigidbody2D;
    BoxCollider2D boxCollider2D;


    [SerializeField] private Vector2 currentTargetPos;
    [SerializeField] private bool isMoving;
    Transform playerPos;



    private void Awake()
    {
        startPosition = transform.position;

        spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        spriteRenderer.sprite = nPCInfo.Sprite;
        _rigidbody2D.gravityScale = 0;

    }
    private void Start()
    {
        SetRandomPosition();
    }
    private void Update()
    {
        if (IsPatrol())
            Patrol();
        else
            Chase();
    }

    bool IsPatrol()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < nPCInfo.patrolDistance)
            return false;
        else
            return true;
    }

    public void Patrol()
    {
        MoveTargetPoint();



    }

    public void Chase()
    {

        SetPosition(playerPos.position);
        MoveTargetPoint();
    }

    private void MoveTargetPoint()
    {
        float moveSpeed = UnityEngine.Random.Range((float)nPCInfo.MinSpeed, nPCInfo.MaxSpeed); // using Random = UnityEngine.Random

        if (Vector2.Distance(transform.position, currentTargetPos) < nPCInfo.stopDistance)
        {
            _rigidbody2D.velocity = Vector2.zero;
            isMoving = true;

            //if(isMoving)
            //    StartCoroutine(SetRandomPositionCoroutine()); //Invoke(nameof(SetRandomPosition), 1f); // À§¶û µ¿ÀÏ
            if (IsPatrol())
                SetRandomPosition();



        }
        else
        {
            _rigidbody2D.velocity = (currentTargetPos - (Vector2)transform.position).normalized * moveSpeed;
        }

    }

    private Vector2 startPosition;
    private void SetRandomPosition()
    {
        //currentTargetPos = (Vector2)transform.position + UnityEngine.Random.insideUnitCircle * nPCInfo.PatrolRadius;
        currentTargetPos = startPosition + UnityEngine.Random.insideUnitCircle * nPCInfo.PatrolRadius;
    }

    public void SetPosition(Vector2 position)
    {
        currentTargetPos = position;
    }

    private IEnumerator SetRandomPositionCoroutine()
    {
        isMoving = false;
        yield return new WaitForSeconds(1f);
        SetRandomPosition();

    }

    private void OnDrawGizmos()
    {
        DrawChaseCircle();
    }

    private void OnDrawGizmosSelected()
    {
        //DrawChaseCircle();
    }

    private void DrawChaseCircle()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, nPCInfo.patrolDistance);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collisionEvent == CollisionEvent.Friendly)
            {
                Bus<ICollisionWithPlayerEvent>.Raise(new ICollisionWithPlayerEvent(this));
                gameObject.SetActive(false);
            }
            else if (collisionEvent == CollisionEvent.UnFriendly)
            {

            }
            else
            {

            }

            Bus<IScoreUpdateEvent>.Raise(new IScoreUpdateEvent(10));
            //ScoreManager.Instance.Score += 10;



        }
    }

}
