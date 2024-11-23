using UnityEngine;

public class SawMovement : MonoBehaviour
{
    public float rotationSpeed = 100f; // Saw objesinin ne kadar hızlı döneceğini belirler.
    public float moveSpeed = 2f; // Saw objesinin ne kadar hızlı hareket edeceğini belirler.
    public float distance = 2f; // Saw objesinin ne kadar mesafe hareket edeceğini belirler.

    private Vector3 startPos;
    private float startPosX;
    private bool moveRight = true;

    void Start()
    {
        startPos = transform.position; // Başlangıç pozisyonunu saklar.
        startPosX = startPos.x;
    }
    void Update()
    {
        // Saw objesi saat yönünün tersine döner.
        transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);

        // Saw objesi sağa ve sola doğru hareket eder.
        if (transform.position.x > startPosX + distance) moveRight = false;
        if (transform.position.x < startPosX - distance) moveRight = true;

        if (moveRight)
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}