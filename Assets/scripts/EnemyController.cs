using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Tank
{
    private Rigidbody2D rb2d;
    private float h, v;
    [SerializeField]
    private LayerMask bordersLayer;
    [SerializeField]
    private LayerMask enemyLayer;

    private enum Direction { Up, Down, Left, Right };

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        RandomDirection();
    }

    public void RandomDirection()
    {
        CancelInvoke("RandomDirection");

        List<Direction> lottery = new List<Direction>();
        if (!HasObstacles(new Vector2(1, 0)))
        {
            lottery.Add(Direction.Right);
        }
        if (!HasObstacles(new Vector2(-1, 0)))
        {
            lottery.Add(Direction.Left);
        }
        if (!HasObstacles(new Vector2(0, 1)))
        {
            lottery.Add(Direction.Up);
        }
        if (!HasObstacles(new Vector2(0, -1)))
        { 
            lottery.Add(Direction.Down);
        }

        Direction selection = lottery[Random.Range(0, lottery.Count)];
        if (selection == Direction.Up)
        {
            v = 1;
            h = 0;
        }
        if (selection == Direction.Down)
        {
            v = -1;
            h = 0;
        }
        if (selection == Direction.Right)
        {
            v = 0;
            h = 1;
        }
        if (selection == Direction.Left)
        {
            v = 0;
            h = -1;
        }

        Invoke("RandomDirection", Random.Range(3, 6));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            RandomDirection();
    }
    private void FixedUpdate()
    {
        if (v != 0 && isMoving == false) StartCoroutine(MoveVertical(v, rb2d));
        else if (h != 0 && isMoving == false) StartCoroutine(MoveHorizontal(h, rb2d));
    }

    private bool HasObstacles(Vector2 direction)
    {
    	return CheckLayerInDirection(direction, bordersLayer) || CheckLayerInDirection(direction, enemyLayer);
    }

    private bool CheckLayerInDirection(Vector2 direction, LayerMask layer)
    {
        Vector2 startPosition = (Vector2)transform.position + direction * 1f;
        Vector2 endPosition = startPosition + direction;
    	return Physics2D.Linecast(startPosition, endPosition, layer);
    }
}