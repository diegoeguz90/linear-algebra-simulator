using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionManager : MonoBehaviour
{
    public static QuaternionManager instance;

    [SerializeField] 
    [Range(0,360)]
    private float angle = 0;

    [SerializeField] Vector3 axis = new(0,1,0);

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Vector3 RotateQuaterion(Vector3 p)
    {
        float q_angle = angle * Mathf.PI / 180;
        Vector3 q_axis = axis;

        return MyQuaterion.Rotate(p, q_axis, q_angle);
    }
}

public struct MyQuaterion
{
    private float x;
    private float y;
    private float z;
    private float w;

    public MyQuaterion(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    private static MyQuaterion RotationQuaternion(float angle, Vector3 axis)
    {
        float sin = Mathf.Sin(angle/2f);
        float cos = Mathf.Cos(angle / 2f);
        Vector3 v = Vector3.Normalize(axis) * sin;

        return new MyQuaterion(v.x, v.y, v.z, cos);
    }

    private static MyQuaterion ConjugateQuaterion(MyQuaterion q)
    {
        float s = q.w;
        Vector3 v = new Vector3(-q.x, -q.y, -q.z);

        return new MyQuaterion(v.x, v.y, v.z, s);
    }

    private static MyQuaterion QuaterionProduct(MyQuaterion q1, MyQuaterion q2)
    {
        float s1 = q1.w;
        float s2 = q2.w;

        Vector3 v1 = new Vector3(q1.x, q1.y, q1.z);
        Vector3 v2 = new Vector3(q2.x, q2.y, q2.z);

        float s = s1 * s2 - Vector3.Dot(v1, v2);
        Vector3 v = s1 * v2 + s2 * v1 + Vector3.Cross(v1, v2);

        return new MyQuaterion(v.x, v.y, v.z, s);
    }

    public static Vector3 Rotate(Vector3 point, Vector3 axis, float angle)
    {
        MyQuaterion q = RotationQuaternion(angle, axis);
        MyQuaterion _q = ConjugateQuaterion(q);
        MyQuaterion p = new MyQuaterion(point.x, point.y, point.z, 0f);

        MyQuaterion rotatedPoint = QuaterionProduct(q, p);
        rotatedPoint = QuaterionProduct(rotatedPoint, _q);

        return new Vector3(rotatedPoint.x, rotatedPoint.y, rotatedPoint.z);
    }
} 
