using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private GameObject m_circlePrefab;
    [SerializeField] int m_totalSamplePoints = 20;
    [SerializeField] float m_separation = 0.6f;
    [SerializeField] float m_amplitude = 0.5f;

    private GameObject[] newPoints;

    private void Start()
    {
        newPoints = new GameObject[m_totalSamplePoints];
        for (int i = 0; i < m_totalSamplePoints; i++)
        {
            newPoints[i] = Instantiate(m_circlePrefab, transform);
        }
    }
    private void Update()
    {
        for (int i = 0; i < newPoints.Length; i++)
        {
            var newPoint = newPoints[i];
            float x = i * m_separation;
            float y = m_amplitude * Mathf.Sin(i + Time.time);
            newPoint.transform.localPosition = new Vector3(x, y);
        }
    }
}
