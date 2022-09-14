using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public struct MyVector
{
    public float x;
    public float y;

    public float magnitud => Mathf.Sqrt(x * x + y * y);
    public MyVector normalized
    {
        get
        {
            float m = magnitud;

            if(m <= 0.0001)
            {
                return new MyVector(0, 0);
            }
            return new MyVector(x / m, y / m);
        }
    }

    public MyVector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public void Draw(Color color)
    {
        Debug.DrawLine(Vector3.zero, new Vector3(x, y, 0), color);
    }
    public void Draw(MyVector newOrigin, Color color)
    {
        Debug.DrawLine(new Vector3(newOrigin.x, newOrigin.y), new Vector3(newOrigin.x + x, newOrigin.y + y), color);
    }

    public void Normalized()
    {
        float cuenta = 0.0001f;
        float m = magnitud;

        if(m <= cuenta)
        {
            x = 0; y = 0;
            return;
        }

        x /= m; y /= m;
    }

    public static MyVector operator +(MyVector a, MyVector b)
    {
        return new MyVector(a.x + b.x, a.y + b.y);
    }
    public static MyVector operator *(MyVector a, float b)
    {
        return new MyVector(a.x * b, a.y * b);
    }
    public static MyVector operator *(float b, MyVector a)
    {
        return new MyVector(a.x * b, a.y * b);
    }
    public static MyVector operator /(MyVector a, float b)
    {
        return new MyVector(a.x / b, a.y / b);
    }
    public static MyVector operator -(MyVector a, MyVector b)
    {
        return new MyVector(a.x - b.x, a.y - b.y);
    }
}

