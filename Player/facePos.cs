using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facePos : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool sagaBakiyor = true; //oyun başında sağa bakacak

    // Joystick referansı
    public Joystick joystick;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //spriteRenderer değişkenini SpriteRenderer bileşeniyle eşleştiriyoruz.
    }

    void Update()
    {
        YuzuCevir(); //Oyuncunun yüzünü çevirmek için bu fonksiyonu kullanıyoruz.
    }

    void YuzuCevir()
    {
        if ((joystick.Horizontal < 0) && sagaBakiyor)
        {
            // Karakter sola gidiyorsa ve yüzü sağa bakıyorsa, yüzü sola çevir
            spriteRenderer.flipX = true;
            sagaBakiyor = false;
        }
        else if ((joystick.Horizontal > 0) && !sagaBakiyor)
        {
            // Karakter sağa gidiyorsa ve yüzü sola bakıyorsa, yüzü sağa çevir
            spriteRenderer.flipX = false;
            sagaBakiyor = true;
        }
    }
}
