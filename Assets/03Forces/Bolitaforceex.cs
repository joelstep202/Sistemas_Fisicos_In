using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolitaforceex : MonoBehaviour
{
    private MyVector position;
    [SerializeField] private MyVector velocity;
    [SerializeField] private MyVector acceleration;

    [Header("Coeficientes")]
    [SerializeField] private float densidad = 1;
    [Range(0f, 1f)] [SerializeField] private float dampening = 0.9f;
    [Range(0f, 1f)] [SerializeField] private float friccionCoefi = 0.9f;
    [SerializeField] private float fluidCoefi = 1;
 
    [Header("Forces")]
    [SerializeField] private MyVector wind;
    [SerializeField] private MyVector gravedad;

    private MyVector netForce;
    private MyVector weight;

    [Header("Extra")]
    [SerializeField] private float mass = 1;
    [SerializeField] Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        position = new MyVector(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        position.Draw(Color.blue);
        velocity.Draw(position, Color.red);

        gravedad.Draw(position, Color.black);
        wind.Draw(position, Color.white);
        netForce.Draw(position, Color.red);

        MyVector friccion = CalculoF();
        friccion.Draw(position, Color.red);
    }

    private void FixedUpdate()
    {
        acceleration = new MyVector(0, 0);
        weight = gravedad * mass;
        AplicarFuerza(weight);
        //AplicarFuerza(wind);

        
        if (transform.localPosition.y <=0)
        {
            FriccionFluidos();
        }

        Move();

    }

    public void Move()
    {
        velocity = velocity + Time.fixedDeltaTime * acceleration;
        position = position + Time.fixedDeltaTime * velocity;

        position.x = CheckB(position.x, ref velocity.x);
        position.y = CheckB(position.y, ref velocity.y);

        transform.position = new Vector3(position.x, position.y, 0);
    }

    private float CheckB(float coor, ref float velocity)
    {
        if (Mathf.Abs(coor) >= cam.orthographicSize)
        {
            velocity *= -1;
            coor = Mathf.Sign(coor) * cam.orthographicSize;
            velocity *= dampening;
        }
        return coor;
    }

    private void AplicarFuerza(MyVector force)
    {
        //netForce += force;
        acceleration += force / mass;
    }

    private MyVector CalculoF()
    {
        float netforceNormal = netForce.magnitud;
        float netForceMag = gravedad.magnitud * mass;

        MyVector d = -friccionCoefi * netForceMag * velocity.normalized;
        return d;
    }
    private void FriccionFluidos()
    {
        float frontalArea = transform.localScale.x;
        float v2 = velocity.magnitud;
        float scalarpart = -0.5f * densidad * v2 * v2 * frontalArea * fluidCoefi;
        MyVector friccion = scalarpart * velocity.normalized;
        AplicarFuerza(friccion);
    }
}
