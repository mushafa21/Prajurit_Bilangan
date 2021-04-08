using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Weapon currentWeapon;
    public Weapon currentWeapon1;
    public Weapon currentWeapon2;
    public Rigidbody2D rb;
    public GameObject gameOver;
    public GameObject wep;
    public float speed;
    public float nextFire;
    public Animator animator;
    private Animator animator2;
    private Animator animator3;
    public Joystick joystick;
    public JoystickShoot nembak;
    public int health;
    private bool hit = true;
    private bool tembak;
    private bool hitOff = false;
    public int nomorSenjata = 1;
    private CameraControl camShake;
    [HideInInspector]
    public bool bisaNembak;
    public static bool bisaTembak;
    public AudioClip hurt;
    Vector2 mv;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator =  transform.GetChild(2).GetComponent<Animator>();
        animator2 = GetComponent<Animator>();
        animator3 = transform.GetChild(1).GetChild(0).GetComponent<Animator>();
        camShake = GameObject.FindGameObjectWithTag("Getar").GetComponent<CameraControl>();
    }

    void Update()
    {
        tembak = false;
        if (Input.GetMouseButton(0) && bisaTembak)
            tembak = true;
        Rotation();
        if (health < 1)
        {
            SoundManager.instance.GameOverMusic();
            gameOver.SetActive(true);
            camShake.animator.SetBool("Mati", true);
            Destroy(gameObject);
            Time.timeScale = 0;
        }

 
        wep.GetComponent<SpriteRenderer>().sprite = currentWeapon.currentWeaponSprite;

        if (nomorSenjata == 1)
            currentWeapon = currentWeapon1;
        if (nomorSenjata == 2)
            currentWeapon = currentWeapon2;
        animator3.SetBool("Tembak", tembak);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -19.8f, 17.5f), Mathf.Clamp(transform.position.y, -16f, 18f));
    }
    void FixedUpdate()
    {
        Movement();
        camShake.animator.SetBool("Shake2", hitOff);

    }
    void Movement()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (joystick.inputDir != Vector3.zero)
        {
            moveInput = joystick.inputDir;
        }
        mv = moveInput.normalized * speed;
        rb.MovePosition(rb.position + mv * Time.fixedDeltaTime);

        if (Input.GetMouseButton(0) && bisaTembak)
        {
            if(Time.time >= nextFire)
            {
                currentWeapon.Shoot();
                nextFire = Time.time + 1 / currentWeapon.fireRate;
                tembak = true;
            }
        }
        if (mv == Vector2.zero)
        {
            animator.SetBool("Jalan", false);
        }
        else
        {
            animator.SetBool("Jalan", true);
        }
    }

    void Rotation()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        if(nembak.inputDir != Vector3.zero)
        {
            angle = Mathf.Atan2(nembak.inputDir.y, nembak.inputDir.x) * Mathf.Rad2Deg + 90;
        }
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }

    IEnumerator HitBoxOff()
    {
        hit = false;
        animator2.SetTrigger("Hit");
        yield return new WaitForSeconds(1.5f);
        hit = true;
    }
    void OnTriggerStay2D(Collider2D target)
    {
        if (target.tag == "Musuh")
        {
            if (hit)
            {
                SoundManager.instance.PlayGanti(hurt);
                camShake.animator.SetTrigger("Shake2");
                StartCoroutine(HitBoxOff());
                health--;
                Destroy(GameObject.Find("LifeBox").transform.GetChild(0).gameObject);
            }
            
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PeluruMusuh")
        {
            if (hit)
            {
                SoundManager.instance.PlayGanti(hurt);
                camShake.animator.SetTrigger("Shake2");
                StartCoroutine(HitBoxOff());
                health--;
                Destroy(GameObject.Find("LifeBox").transform.GetChild(0).gameObject);
            }

        }
    }
    public void ChangeWeapon (int amt)
    {
        FindObjectOfType<Player>().nomorSenjata = amt;
    }
}
