using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Kusarigama : MonoBehaviour
{
    public bool IsOnTarget = false;

    [SerializeField] private Transform throwingPoint;
    [SerializeField] private float weaponTicksForPath = 30f;
    [SerializeField] private Throw throwWeapon;

    private Vector2 worldMousePosition2D;
    private RaycastHit2D throwingPath;
    private Vector2 throwingPointPosition;
    private Vector2 kusarigamaCurrentPathPoint;

    private void Update()
    {
        throwingPath = throwWeapon.ThrowingPath;
    }
    public void ThrowStart()
    {
        throwingPointPosition = throwingPoint.position;
        kusarigamaCurrentPathPoint = throwingPointPosition;
        StartCoroutine(KusarigamaFlight());
    }
    private IEnumerator KusarigamaFlight()
    {
        for (int i=0;i<weaponTicksForPath;i++)
        {
            kusarigamaCurrentPathPoint += (throwingPath.point - throwingPointPosition) / weaponTicksForPath;
            gameObject.transform.position = kusarigamaCurrentPathPoint;
            yield return null;
        }
        gameObject.transform.position = throwWeapon.ThrowingPath.point;
        IsOnTarget = true;
    }
}
