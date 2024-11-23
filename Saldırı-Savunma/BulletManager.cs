using UnityEngine;
using UnityEngine.EventSystems;

public class BulletManager : MonoBehaviour
{
    public Transform bullet;
    public float bulletSpeed = 600;
    public float fireRate = 0.31f;
    private float defaultBulletSpeed;
    private float defaultFireRate;
    private float nextFireTime = 0.1f;
    public AudioClip fireSFX;

    private AudioSource audioSource;
    Transform muzzle;

    // Ateş etme butonu referansı
    public GameObject fireButton;

    void Start()
    {
        defaultBulletSpeed = bulletSpeed;
        defaultFireRate = fireRate;
        GameObject muzzleObject = GameObject.FindGameObjectWithTag("Muzzle");
        muzzle = muzzleObject.transform;

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        // EventTrigger bileşenini ekleyip PointerDown olayını dinleyin
        AddEventTriggerListener(fireButton, EventTriggerType.PointerDown, OnFireButtonPressed);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E) && Time.time >= nextFireTime)
        {
            shootbullet();
            nextFireTime = Time.time + 0.1f / fireRate;
        }
    }

    public void OnFireButtonPressed(BaseEventData eventData)
    {
        if (Time.time >= nextFireTime)
        {
            shootbullet();
            nextFireTime = Time.time + 0.1f / fireRate;
        }
    }

    void shootbullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);

        if (fireSFX != null)
        {
            audioSource.volume = 0.35f;
            audioSource.pitch = 1.3f;
            audioSource.PlayOneShot(fireSFX);
        }
    }

    public void ResetBulletStats()
    {
        bulletSpeed = defaultBulletSpeed;
        fireRate = defaultFireRate;
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
}
