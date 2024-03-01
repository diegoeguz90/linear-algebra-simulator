using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossProductManager : MonoBehaviour
{
    [SerializeField] GameObject vector1;
    [SerializeField] GameObject vector2;
    [SerializeField] GameObject result;

    private void Update()
    {
        Vector3 v1 = vector1.transform.position;
        Vector3 v2 = vector2.transform.position;

        result.transform.position = CalculateCrossProduct(v1, v2);
    }

    /// <summary>
    /// Custom function to calculate cross product 
    /// </summary>
    /// <param name="p">vector p</param>
    /// <param name="q">vector q</param>
    /// <returns>pXq</returns>
    private Vector3 CalculateCrossProduct (Vector3 p, Vector3 q)
    {
        float x = p.y * q.z - p.z * q.y;
        float y = p.z * q.x - p.x * q.z;
        float z = p.x * q.y - p.y * q.x;

        return new Vector3(x, y, z);
    }
}
