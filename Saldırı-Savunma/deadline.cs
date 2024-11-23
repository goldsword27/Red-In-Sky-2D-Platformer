using UnityEngine;

public class DeadlineCollider : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joystickHandle;
    public GameObject shotButton;
    public GameObject jumpButton;

    void Start()
    {
        if (joystick == null)
        {
            joystick = GameObject.FindWithTag("Joystick");
        }

        if (joystick != null && joystickHandle == null)
        {
            joystickHandle = joystick.transform.Find("Handle")?.gameObject;
        }

        if (shotButton == null)
        {
            shotButton = GameObject.FindWithTag("ShotButton");
        }

        if (jumpButton == null)
        {
            jumpButton = GameObject.FindWithTag("JumpButton");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Die();
                SetActiveAllControls(false);
            }
        }
    }

    void SetActiveAllControls(bool isActive)
    {
        if (joystick != null)
        {
            joystick.SetActive(isActive);
        }

        if (joystickHandle != null)
        {
            joystickHandle.SetActive(isActive);
        }

        if (shotButton != null)
        {
            shotButton.SetActive(isActive);
        }

        if (jumpButton != null)
        {
            jumpButton.SetActive(isActive);
        }
    }
}
