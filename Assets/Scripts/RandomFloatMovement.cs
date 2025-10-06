using UnityEngine;

public class RandomFloatMovement : MonoBehaviour
{
    public float amplitude = 0.1f;   // Intensidade do movimento
    public float speed = 1.0f;       // Velocidade da variação

    private Vector3 startPosition;
    private float offsetX;
    private float offsetY;

    void Start()
    {
        startPosition = transform.localPosition;

        // Gera offsets aleatórios para evitar que múltiplos objetos oscilem iguais
        offsetX = Random.Range(0f, 100f);
        offsetY = Random.Range(0f, 100f);
    }

    void Update()
    {
        float x = Mathf.PerlinNoise(Time.time * speed + offsetX, 0f) - 0.5f;
        float y = Mathf.PerlinNoise(0f, Time.time * speed + offsetY) - 0.5f;

        Vector3 offset = new Vector3(x, y, 0f) * amplitude;
        transform.localPosition = startPosition + offset;
    }
}