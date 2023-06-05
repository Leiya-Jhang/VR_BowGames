using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatString : MonoBehaviour
{
    [SerializeField] private Transform startPoint, endPoint;

    private LineRenderer lineRenderer;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void CreatBowString(Vector3? midPosition)
    {
        Vector3[] linePoints = new Vector3[midPosition == null ? 2 : 3];
        linePoints[0] = startPoint.localPosition;
        if (midPosition != null)
        {
            linePoints[1] = transform.InverseTransformPoint(midPosition.Value);
        }

        linePoints[^1] = endPoint.localPosition;
        lineRenderer.positionCount = linePoints.Length;
        lineRenderer.SetPositions(linePoints);
    }

    private void Start()
    {
        CreatBowString(null);
    }
}
