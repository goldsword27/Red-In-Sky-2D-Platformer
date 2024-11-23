using UnityEngine;

public class sallananMace : MonoBehaviour
{
    HingeJoint2D hinge;
    float maxSpeed = 100f; // Maksimum hız
    float minSpeed = 50f;  // Minimum hız
    float targetSpeed = 100f; // Başlangıç hızı
    bool hasReachedLimit = false;

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        // HingeJoint2D bileşenine erişim sağlayın.
        hinge.useMotor = true; // Motoru etkinleştirin
        JointMotor2D motor = hinge.motor;
        motor.motorSpeed = targetSpeed;
        hinge.motor = motor;
    }

    void Update()
    {
        JointMotor2D motor = hinge.motor;
        float angleAbs = Mathf.Abs(hinge.jointAngle);
        float t = angleAbs / 90f; // 0 ile 1 arasında bir değer

        // Kenarlara yaklaştıkça yavaşla, ortada hızlan
        float currentSpeed = Mathf.Lerp(maxSpeed, minSpeed, t);
        motor.motorSpeed = currentSpeed * Mathf.Sign(motor.motorSpeed);

        // Eğer Mace belirli bir sınıra ulaştığında, dönüş yönünü tersine çevirin.
        if ((hinge.jointAngle > 90f || hinge.jointAngle < -90f) && !hasReachedLimit)
        {
            motor.motorSpeed = -motor.motorSpeed; // Hızı tersine çevirin
            hinge.motor = motor;
            hasReachedLimit = true; // Limite ulaşıldığını işaretleyin
        }
        // Eğer sınırdan çıkarsa, tekrar limite ulaşılmadığını işaretleyin.
        if (hinge.jointAngle < 90f && hinge.jointAngle > -90f)
        {
            hasReachedLimit = false;
        }

        hinge.motor = motor;
    }
}
