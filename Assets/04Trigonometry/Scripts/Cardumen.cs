using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardumen : MonoBehaviour
{
    [SerializeField] private Vector3 acceleration;
    [SerializeField] private Vector3 speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = GetWorldMouse();
        acceleration = mousePos - transform.position;
        speed += acceleration * Time.deltaTime;
        speed.z = 0;
        transform.position += speed * Time.deltaTime;
        float angle = Mathf.Atan2(speed.y, speed.x) - Mathf.PI / 2f;
        
        RotarZ(angle);
    }

    private void RotarZ(float angleR)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, angleR * Mathf.Rad2Deg);
    }

    private void Movimiento(Vector3 queso)
    {
        if (queso.magnitude > 1f)
        {
            transform.position += speed * Time.deltaTime;
        }
    }

    private Vector3 GetWorldMouse()
    {
        Camera camara = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camara.nearClipPlane);
        Vector4 worldPos = camara.ScreenToWorldPoint(screenPos);
        return worldPos;
    }
}
