using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBolita : MonoBehaviour
{
    public Camera camera;
    private MyVector position;
    private MyVector displacement;
    [SerializeField] private MyVector acceleration;
    [SerializeField] private MyVector velocity;
    [Range(0, 1)] [SerializeField] private float damping = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        position = new MyVector(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        position.Draw(Color.blue);
        displacement.Draw(Color.red);

        Move();
        Cambio();
    }

    public void Move()
    {
        velocity = velocity + acceleration * Time.deltaTime;
        position = position + velocity * Time.deltaTime;

        if(Mathf.Abs(transform.position.x) > camera.orthographicSize)
        {
            velocity *= -1;
            position.x = Mathf.Sign(position.x) * camera.orthographicSize;
            velocity *= damping;
        }
        if (Mathf.Abs(transform.position.y) > camera.orthographicSize)
        {
            velocity.y *= -1;
            position.y = Mathf.Sign(position.y) * camera.orthographicSize;
            velocity *= damping;
        }
        transform.position = new Vector3(position.x, position.y);
    }

    public void Cambio()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(acceleration.x > 0)
            {
                acceleration.y = acceleration.x;
                acceleration.x = 0;
                velocity.x = 0;
            }
            else if (acceleration.x < 0)
            {
                acceleration.y = acceleration.x;
                acceleration.x = 0;
                velocity.x = 0;
            }
            else if (acceleration.y > 0)
            {
                acceleration.x -= acceleration.y;
                acceleration.y = 0;
                velocity.y = 0;
            }
            else if (acceleration.y < 0)
            {
                acceleration.x -= acceleration.y;
                acceleration.y = 0;
                velocity.y = 0;
            }
        }
    }
}
