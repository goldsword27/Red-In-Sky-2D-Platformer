using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacControl : MonoBehaviour
{
    public float OyuncuHizi = 8f;
    private float defaultSpeed;
    private Rigidbody2D yatayhareket; 
    private Transform muzzle; // Muzzle nesnesini tutmak için
    private bool isDead = false; // Oyuncunun ölü olup olmadığını takip etmek için

    // Joystick referansı
    public Joystick joystick;

    // Animator referansı
    private Animator animator;

    void Start()
    {
        defaultSpeed = OyuncuHizi;
        yatayhareket = GetComponent<Rigidbody2D>();
        muzzle = GameObject.FindGameObjectWithTag("Muzzle").transform;

        // Animator bileşenini al
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead)
        {
            OyuncuHareketi();
            RotateMuzzle();
        }
    }

    void OyuncuHareketi()
    {
        // Mobil cihaz için joystick input'u kullan
        float horizontalInput = joystick.Horizontal;

        // Eşik değeri belirleyerek küçük girdileri yok sayabiliriz
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            // Joystick'in yönüne göre sabit hız belirleme
            float direction = Mathf.Sign(horizontalInput);
            yatayhareket.velocity = new Vector2(direction * OyuncuHizi, yatayhareket.velocity.y);

            // Animator parametresine değeri atama (Animasyonlar için)
            animator.SetFloat("KosmaAnim", Mathf.Abs(horizontalInput));
        }
        else
        {
            yatayhareket.velocity = new Vector2(0, yatayhareket.velocity.y);
        }
    }

    void RotateMuzzle()
    {
        float direction = joystick.Horizontal;

        // Player sağa dönüyorsa
        if (direction > 0.1f)
        {
            // Muzzle nesnesini sağa döndür
            if (muzzle != null)
            {
                muzzle.localPosition = new Vector3(0.596f, 0.45f, 1);
                muzzle.localRotation = Quaternion.Euler(-10, 90, 0);
            }
        }
        // Player sola dönüyorsa
        else if (direction < -0.1f)
        {
            // Muzzle nesnesini sola döndür
            if (muzzle != null)
            {
                muzzle.localPosition = new Vector3(-0.596f, 0.45f, 1);
                muzzle.localRotation = Quaternion.Euler(-10, -90, 0);
            }
        }
    }

    public void Die()
    {
        isDead = true;
        yatayhareket.velocity = Vector2.zero; // Oyuncunun hareketini durdur
    }

    public void SetSpeed(float newSpeed)
    {
        OyuncuHizi = newSpeed;
    }

    public void ResetSpeed()
    {
        OyuncuHizi = defaultSpeed;
    }
}
