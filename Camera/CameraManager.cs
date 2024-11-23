using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target; // Oyuncunun Transform bileşeni
    public float smoothSpeed = 0.125f; // Takip etme hızı
    public Vector3 offset; // Kamera ile oyuncu arasındaki mesafe
    public float jumpHeight = 2f; // Zıplama yüksekliği

    private bool isJumping = false; // Zıplama durumunu kontrol etmek için

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            Jump();
        }
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    void Jump()
    {
        isJumping = true;
        Vector3 jumpTarget = new Vector3(target.position.x, target.position.y + jumpHeight, transform.position.z) + offset;
        transform.position = Vector3.Lerp(transform.position, jumpTarget, 0.5f);
        Invoke("ResetJump", 0.5f);
    }

    void ResetJump()
    {
        isJumping = false;
    }
}
