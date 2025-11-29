using UnityEngine;

public class SmoothUpDown : MonoBehaviour
{
    public float amplitude = 1f;  // Dalganýn yüksekliði
    public float frequency = 1f;  // Hýz

    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        float newY = startY + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
