using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jump : MonoBehaviour
{
    private Rigidbody2D yatayhareket;
    public float jumpSpeed = 300f;
    public bool isGrounded = false;
    public Transform GroundCheckPosition;
    public float GroundCheckRadius, jumpFrequency = 1f, nextJumpTime;
    public LayerMask GroundCheckLayer;
    private Animator playerAnimator;
    public float guclendirilmisJump = 500f;

    // Zıplama butonu referansı
    public GameObject jumpButton;

    // Zıplama ses efekti
    public AudioClip jumpSound;
    public AudioClip boostSound;
    private AudioSource audioSource;

    void Start()
    {
        yatayhareket = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        // AudioSource bileşenini başlat
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // EventTrigger bileşenini ekleyip PointerDown olayını dinleyin
        AddEventTriggerListener(jumpButton, EventTriggerType.PointerDown, OnJumpButtonPressed);
    }

    void Update()
    {
        OnGroundCheck();
    }

    public void OnJumpButtonPressed(BaseEventData eventData)
    {
        if (isGrounded && nextJumpTime < Time.timeSinceLevelLoad)
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            jump();
        }
    }

    void jump()
    {
        yatayhareket.AddForce(new Vector2(0f, jumpSpeed));
        PlaySound(jumpSound);
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheckPosition.position, GroundCheckRadius, GroundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isGrounded);
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.pitch = 1.0f;
            audioSource.volume = 1f;
            audioSource.PlayOneShot(clip);
        }
    }

    void AddEventTriggerListener(GameObject target, EventTriggerType eventType, System.Action<BaseEventData> callback)
    {
        EventTrigger trigger = target.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = target.AddComponent<EventTrigger>();
        }
        var entry = new EventTrigger.Entry { eventID = eventType };
        entry.callback.AddListener(new UnityEngine.Events.UnityAction<BaseEventData>(callback));
        trigger.triggers.Add(entry);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("JumpBoost"))
        {
            jumpSpeed = guclendirilmisJump;
            PlaySound(boostSound);
            StartCoroutine(ScaleAndDestroy(other.gameObject));
        }
    }

    IEnumerator ScaleAndDestroy(GameObject obj)
    {
        float duration = 0.5f;
        Vector3 initialScale = obj.transform.localScale;
        Vector3 targetScale = initialScale * 1.5f;

        float time = 0f;
        while (time < duration)
        {
            obj.transform.localScale = Vector3.Lerp(initialScale, targetScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        Destroy(obj);
    }
}
