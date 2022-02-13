using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poruszanie_przeciwnik : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private LayerMask ground;
    private Vector2 targetVelovity;
    private Rigidbody2D rigidbody;
    private bool isFacingRight = false;
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
            startOfLine = new Vector2(10f, 0f);
        }
        targetVelovity = new Vector2(-speed, 0f);
        //startOfLine = new Vector2(linePositionX, 0);
        Movement();
        Edge();
        //Flip();
        Debug.Log(rigidbody.velocity.x);
    }
    private void Movement()
    {
        if (rigidbody.velocity.x>-speed || rigidbody.velocity.x<speed)
        {
            rigidbody.velocity += targetVelovity;
        }
        
    }
    private void Flip()
    {
        
                
            transform.Rotate(0, 180, 0);
            isFacingRight = !isFacingRight;
           // startOfLine = new Vector2(-linePositionX, 0);                          
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
