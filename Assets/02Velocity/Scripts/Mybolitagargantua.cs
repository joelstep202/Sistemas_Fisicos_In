using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mybolitagargantua : MonoBehaviour
{
    private MyVector position;
    [SerializeField] private MyVector acceleration;
    [SerializeField] private MyVector velocity;
    [Range(0, 1)] [SerializeField] private float damping = 0.9f;

    [Header("World")]
    [SerializeField] private Camera camera;

    [SerializeField] private Transform blackhole;
    private MyVector blackholet;
    private MyVector positionT;

    // Start is called before the first frame update
    void Start()
    {
        position = new MyVector(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        acceleration.Draw(position, Color.blue);

        MyVector positionT = new MyVector(transform.position.x, transform.position.y);
        MyVector blackholet = new MyVector(blackhole.position.x, blackhole.position.y);

        acceleration = blackholet - positionT;
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;

        /*if (Mathf.Abs(transform.position.x) > camera.orthographicSize)
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
        }*/

        transform.position = new Vector3(position.x, position.y);
    }
}
