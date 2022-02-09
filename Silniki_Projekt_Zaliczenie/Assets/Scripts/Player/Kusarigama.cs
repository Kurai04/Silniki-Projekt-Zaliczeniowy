using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Kusarigama : MonoBehaviour
{
    [SerializeField] private Transform throwingPoint;
    [SerializeField] float pullForce = 10f;
    private Vector2 worldMousePosition2D;
    private Rigidbody2D rigidboody;
    private void Awake()
    {
        rigidboody = gameObject?.GetComponent<Rigidbody2D>() ?? gameObject.AddComponent<Rigidbody2D>();
        throwingPoint = throwingPoint.GetComponent<Transform>();
    }
    private void Update()
    {
        var mousePosiotion = Mouse.current.position.ReadValue();
        var worldPosition = Camera.main.ScreenToWorldPoint(mousePosiotion);
        worldMousePosition2D = new Vector2(worldPosition.x, worldPosition.y);
        Throw();
    }
    private void Throw()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            var throwingPath = Physics2D.Raycast(new Vector2(throwingPoint.position.x, throwingPoint.position.y), new Vector2(worldMousePosition2D.x, worldMousePosition2D.y));
            if(throwingPath)
            {
            rigidboody.AddForce((worldMousePosition2D - new Vector2(throwingPoint.position.x, throwingPoint.position.y))*pullForce,ForceMode2D.Force);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(new Vector2(throwingPoint.position.x, throwingPoint.position.y), new Vector2(worldMousePosition2D.x, worldMousePosition2D.y));
    }
}
