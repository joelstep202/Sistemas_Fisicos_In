using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class espiralbolita : MonoBehaviour
{
    [SerializeField] float radio;
    [SerializeField] float angleDeg;
    [SerializeField] Transform bolita;
    [SerializeField] Camera camara;

    [SerializeField] float angularSpeed;
    [SerializeField] float radialSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(bolita, "La bolita es necesaria");
    }

    // Update is called once per frame
    void Update()
    {
        BoundsBounds(camara, bolita);
        angleDeg += angularSpeed * Time.deltaTime;
        radio += radialSpeed * Time.deltaTime;

        bolita.position = PolarACarte(radio, angleDeg);
        Debug.DrawLine(Vector3.zero, bolita.position, Color.red);
    }

    private Vector3 PolarACarte(float radio, float angulo)
    {
        float x = radio * Mathf.Cos(angulo * Mathf.Deg2Rad);
        float y = radio * Mathf.Sin(angulo * Mathf.Deg2Rad);
        return new Vector3(x, y, 0);
    }

    private void BoundsBounds(Camera camara, Transform bolita)
    {
        if(Mathf.Abs(bolita.position.x) > camara.orthographicSize)
        {
            radialSpeed = -radialSpeed;
            angularSpeed = -angularSpeed;
        }
        if(Mathf.Abs(bolita.position.y) > camara.orthographicSize)
        {
            radialSpeed = -radialSpeed;
            angularSpeed = -radialSpeed;
        }
    }
}
