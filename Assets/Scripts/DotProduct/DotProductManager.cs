using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DotProductManager : MonoBehaviour
{
    [SerializeField] GameObject Vector1;
    [SerializeField] GameObject Vector2;
    [SerializeField] TMP_Text v1dotv2Txt;

    private void Update()
    {
        Vector3 v1 = Vector1.transform.position;
        Vector3 v2 = Vector2.transform.position;

        Vector3 c = Vector3.zero;

        v1dotv2Txt.text = "v1.v2 = " + CalculateDotProduct(v1,v2,c);
    }

    /// <summary>
    /// Calculates the dot product 
    /// </summary>
    /// <param name="p0">Vector1</param>
    /// <param name="p1">Vector2</param>
    /// <param name="c">Vector of reference</param>
    /// <returns>p0.p1</returns>
    private string CalculateDotProduct(Vector3 p0, Vector3 p1, Vector3 c)
    {
        Vector3 a = (p0 - c).normalized;
        Vector3 b = (p1 - c).normalized;

        float adotb = (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
        return adotb.ToString("F2");
    }
}
