using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawVectorLine : MonoBehaviour
{
    private Vector3 p0 = Vector3.zero;
    private Vector3 p1 = new();
    LineRenderer vectorLine;
    private void Start()
    {
        vectorLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        p1 = transform.position;
        vectorLine.SetPositions(new Vector3[] { p0, p1 });
    }
}
