using UnityEngine;

public class SpiralOscillation : MonoBehaviour
{
    public float amplitude = 1.0f;   // Amplitude of oscillation
    public float frequency = 1.0f;   // Frequency of oscillation
    public float spiralFactor = 1.0f; // Spiral factor controls how tight the spiral is

    private Vector3 initialPosition;
    private float time = 0.0f;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        time += Time.deltaTime;

        float x = Mathf.Sin(time * frequency) * amplitude;
        float y = Mathf.Cos(time * frequency) * amplitude;
        float z = time * spiralFactor;

        Vector3 newPosition = initialPosition + new Vector3(x, y, z);

        transform.position = newPosition;
    }
}






