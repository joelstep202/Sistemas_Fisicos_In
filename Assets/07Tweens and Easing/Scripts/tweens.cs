using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tweens : MonoBehaviour
{
    float currentTime = 0f;
    Vector3 initialPosition;
    Vector3 targetPosition;

    [SerializeField] float time = 0f;
    [SerializeField, Range(0, 1)] float timeN = 0;
    [SerializeField] Color initialColor;
    [SerializeField] Color targetColor;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] Transform target;
    private SpriteRenderer render;

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
        Tween();
    }

    private void Update()
    {
        timeN = currentTime / time;
        transform.position = Vector3.Lerp(initialPosition, targetPosition, curve.Evaluate(timeN));
        render.material.color = Color.Lerp(initialColor, targetColor, curve.Evaluate(timeN));
        currentTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Tween();
        }
    }
    private void Tween()
    {
        timeN = 0;
        currentTime = 0;
        initialPosition = transform.position;
        targetPosition = target.position;
    }
    private float EaseInElastic(float x)
    {
        float c5 = (2f * Mathf.PI) / 4.5f;
        return x == 0f
          ? 0f
          : x == 1f
          ? 1f
          : x < 0.5
          ? -(Mathf.Pow(2f, 20f * x - 10f) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2f
          : (Mathf.Pow(2f, -20f * x + 10f) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2f + 1f;
    }
}
