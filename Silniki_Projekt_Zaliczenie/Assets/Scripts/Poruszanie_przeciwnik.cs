using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poruszanie_przeciwnik : MonoBehaviour
{
    [SerializeField] private float speed = -2f;
    [SerializeField] private LayerMask ground;
    private Vector2 targetVelovity;
    private Rigidbody2D rigidbody;
    private bool isFacingRight = true;
    private Vector3 startOfLine;
    private float linePositionX = -1f;
    [SerializeField] private float lineLenght = 5f;

    private void Awake()
    {        
        rigidbody = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        if(!isFacingRight)
        {
            startOfLine = new Vector2(-1f, 0f);
        }
        else
        {
            startOfLine = new Vector2(1f, 0f);
        }
        targetVelovity = new Vector2(speed, 0f);
        Movement();
        Edge();
        Debug.Log(rigidbody.velocity.x);
    }
    private void Movement()
    {
        var maxSpeed = 10;
        if (rigidbody.velocity.x <= maxSpeed&&rigidbody.velocity.x>=-maxSpeed)
        rigidbody.velocity += targetVelovity;
    }
    private void Flip()
    {  
            transform.Rotate(0, 180, 0);
            isFacingRight = !isFacingRight;
    }
    private void Edge()
    {
        var raycast = Physics2D.RaycastAll(transform.position+startOfLine, Vector2.down,lineLenght,ground);
        if (raycast.Length<1)
        {
            rigidbody.velocity += new Vector2(-rigidbody.velocity.x, 0f);
            speed = -speed;
            Flip();
        }
    }
}
