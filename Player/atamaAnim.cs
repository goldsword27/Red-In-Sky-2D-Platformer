using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atamaAnim : MonoBehaviour
{
    public float OyuncuHizi = 5f; // Dışarıdan erişilebilir karakter hızı ayarı 
    private Rigidbody2D yatayhareket;
    private Animator animator;  // Animator bileşenini tanımla

    // Joystick referansı
    public Joystick joystick;

    void Start()
    {
        yatayhareket = GetComponent<Rigidbody2D>();  // Rigidbbody'i yatayhareket'e atama yapma. Kolaylık olsun diye
        animator = GetComponent<Animator>();  // Animator bileşenini al
    }

    void Update()
    {
        OyuncuHareketi(); // Fonksiyon çağırma
    }

    void OyuncuHareketi()    // Fonksiyon tanımlama
    {
        // Mobil cihaz için joystick input'u kullan
        float horizontalInput = joystick.Horizontal;

        // Eşik değeri belirleyerek küçük girdileri yok sayabiliriz
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            // Joystick'in yönüne göre sabit hız belirleme
            float direction = Mathf.Sign(horizontalInput);
            yatayhareket.velocity = new Vector2(direction * OyuncuHizi, yatayhareket.velocity.y);
        }
        else
        {
            // Yatay hareket yoksa, hızını sıfırla
            yatayhareket.velocity = new Vector2(0, yatayhareket.velocity.y);
        }

        // Animator parametresine değeri atama
        animator.SetFloat("KosmaAnim", Mathf.Abs(horizontalInput));
    }

    public void SetSpeed(float newSpeed)
    {
        OyuncuHizi = newSpeed;
    }
}
