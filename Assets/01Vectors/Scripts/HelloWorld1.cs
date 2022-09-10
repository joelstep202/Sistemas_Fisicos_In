using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class HelloWorld1 : MonoBehaviour
{
    [SerializeField] MyVector fisrtVec = new MyVector(2, 3);
    [SerializeField] MyVector secondtVec = new MyVector(3, 4);
    [Range(0, 1)] [SerializeField] float scalar = 0;

    // Start is called before the first frame update
    void Start()
    {
        MyVector a = new MyVector(3, 4);
        MyVector b = new MyVector(5, 6);
        MyVector c = a + b;
        Debug.Log(c.x);
        Debug.Log(c.y);

        Vector2 au = new Vector2(2, 3);
        Vector2 bu = new Vector2(4, 5);
        Vector2 cu = au + bu;
    }
    private void Update()
    {
        MyVector diff = (secondtVec - fisrtVec) * scalar;
        MyVector final = fisrtVec + diff;
        MyVector cami = (secondtVec - fisrtVec);

        fisrtVec.Draw(Color.red);
        secondtVec.Draw(Color.yellow);
        cami.Draw(fisrtVec, Color.green);

        diff.Draw(Color.blue);
        diff.Draw(fisrtVec, Color.white);
        final.Draw(Color.yellow);
        //MyVector result = fisrtVec + secondtVec;
        //result.Draw(Color.yellow);


    }
}
