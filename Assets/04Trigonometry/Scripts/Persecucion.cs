using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persecucion : MonoBehaviour
{
    [SerializeField] float velocidad = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = GetWorldMouse();
        Vector3 direccion = mousePos - transform.position;
        float angle = Mathf.Atan2(direccion.y, direccion.x) - Mathf.PI / 2;
        RotarZ(angle);
        Movimiento(direccion);
    }

    private void RotarZ(float angleR)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, angleR * Mathf.Rad2Deg);
    }

    private void Movimiento(Vector3 queso)
    {
        if(queso.magnitude > 1f)
        {
            transform.position += queso.normalized * velocidad * Time.deltaTime;
        }
    }

    private Vector4 GetWorldMouse()
    {
        Camera camara = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camara.nearClipPlane);
        Vector4 worldPos = camara.ScreenToWorldPoint(screenPos);
        return worldPos;
    }
}
