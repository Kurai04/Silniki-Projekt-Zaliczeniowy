using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public LineRenderer lineRenderer;

    [SerializeField] private Transform throwingPoint;
    [SerializeField] private Transform conectionPoint;

    private Vector3[] linePoints = new Vector3[2];
    private void Update()
    {
        linePoints[0]=throwingPoint.transform.position;
        linePoints[1] = conectionPoint.transform.position;
        lineRenderer.SetPositions(linePoints);
    }
}
