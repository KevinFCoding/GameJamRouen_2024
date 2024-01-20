using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaking : MonoBehaviour
{

    [SerializeField]
    private Transform m_Target;

    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private Vector3 m_Offset;

    public float duration = 1f;

    public bool shakeshake = false;

    void Update()
    {
        try
        {
            transform.position = Vector3.Lerp(transform.position, m_Target.position + m_Offset, m_Speed * Time.deltaTime);
            if (shakeshake)
            {
                shakeshake = false;
                StartCoroutine(Shaking());
            }
        }
        catch { return; }

    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < 0.05)
        {
            elapsedTime += Time.deltaTime;
            transform.position = startPosition + Random.insideUnitSphere;

            yield return null;
        }
        transform.position = startPosition;
        shakeshake = false;
    }
}
