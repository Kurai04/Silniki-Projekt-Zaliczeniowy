using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Throw : MonoBehaviour
{
    public RaycastHit2D ThrowingPath;

    [SerializeField] private Transform throwingPoint;
    [SerializeField] private float pullForce = 10f;
    [SerializeField] private float throwingRange = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject kusarigama;

    private Vector2 worldMousePosition2D;
    private Rigidbody2D rigidboody;
    private Vector2 throwingPointPosition;
    private Vector2 kusarigamaCurrentPathPoint;
    private Quaternion weaponRotation = new Quaternion(0, 0, 0, 0);
    private Kusarigama weapon;
    private void Awake()
    {
        kusarigama.transform.position = throwingPoint.position;
        weapon = kusarigama.GetComponent<Kusarigama>();
        kusarigama.SetActive(false);
        rigidboody = gameObject?.GetComponent<Rigidbody2D>() ?? gameObject.AddComponent<Rigidbody2D>();
    }
    private void Update()
    {
        var mousePosiotion = Mouse.current.position.ReadValue();
        var worldPosition = Camera.main.ScreenToWorldPoint(mousePosiotion);
        worldMousePosition2D = new Vector2(worldPosition.x, worldPosition.y);
        throwingPointPosition = new Vector2(throwingPoint.position.x, throwingPoint.position.y);
        ThrowWeapon();
    }
    private void ThrowWeapon()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            ThrowingPath = Physics2D.Raycast(throwingPointPosition, new Vector2(worldMousePosition2D.x, worldMousePosition2D.y), throwingRange, groundLayer);
            if (ThrowingPath)
            {
                kusarigama.SetActive(true);
                weapon.ThrowStart();
                rigidboody.AddForce((worldMousePosition2D - new Vector2(throwingPoint.position.x, throwingPoint.position.y)) * pullForce, ForceMode2D.Force);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(throwingPointPosition, new Vector2(worldMousePosition2D.x, worldMousePosition2D.y));
    }
}
