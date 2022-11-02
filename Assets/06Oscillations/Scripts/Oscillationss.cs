using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillationss : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    float period = 1;

    [SerializeField]
    [Range(0, 10)]
    private float amplitude = 2;

    [SerializeField] private bool diagonal = false;

    float inicialx = 0;
    float inicialy = 0;

    private void Start()
    {
        inicialx = transform.position.x;
        inicialx = transform.position.y;
    }
    void Update()
    {
        float factor = Time.time / period;
        float x = amplitude * Mathf.Sin(2 * Mathf.PI * factor);

        if (diagonal != true)
        {
            transform.position = new Vector3(inicialx + x, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(inicialx + x, inicialy + x, transform.position.z);
        }
    }
}
