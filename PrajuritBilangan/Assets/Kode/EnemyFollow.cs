using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private GameObject player;
    public Animator animator;
    public GameObject matiPrefab;
    public float speed;
    public float delay;
    public Rigidbody2D rb;
    public Vector2 movement;
    public int health = 3;
    public string jenisPeluru;
    public string enggakPeluru;
    protected float Timer;
    public bool kena = false;
    public bool enggakKena = false;
    private CameraControl camShake;
    public AudioClip hancur;
    public AudioClip dong;
    public AudioClip tang;
    public AudioClip laser;
    public Vector3 direction;
    public bool merah = false;
    public bool hijau = false;
    public bool deffense = false;
    public GameObject tembakan;
    public GameObject bulletPrefab;
    public float nextFire;
    public bool tembak = true;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("PlayerFix");
        animator = GetComponent<Animator>();
        camShake = GameObject.FindGameObjectWithTag("Getar").GetComponent<CameraControl>();
        tembakan = GameObject.Find("HijauPoint");
    }


    void Update()
    {
        if (player != null)
            direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        if (health < 1 )
        {
            camShake.animator.SetTrigger("Shake2");
            Manager.winCon++;
            GameObject bullet = Instantiate(matiPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        Timer += Time.deltaTime;

        if (Timer >= delay)
        {
            Timer = 0f;
            speed = speed + 0.001f;
        }
        if (player != null)
        {
            if (hijau)
            {
                if (tembak)
                {
                    if (Vector2.Distance(player.transform.position, transform.position) < 10f)
                        if (Time.time >= nextFire)
                        {
                            Shoot();
                            SoundManager.instance.PlayGanti(laser);
                            tembak = false;
                            StartCoroutine(Reload());
                        }
                }
            }
        }
        IEnumerator Reload()
        {
            yield return new WaitForSeconds(2f);
            tembak = true;
        }
        if (Time.timeScale == 0)
            GetComponent<ScreenIndicator>().enabled = false;
        else
            GetComponent<ScreenIndicator>().enabled = true;
    }
    
    private void FixedUpdate()
    {
        if (player == true)
        moveCharacter(movement);

        animator.SetBool("Kena", kena);
        animator.SetBool("EnggakKena", enggakKena);
        camShake.animator.SetBool("Shake", kena);
        if (player == false)
        {
            speed = 0f;
        }
            
    }

    void moveCharacter(Vector2 direction)
    {
      
            if (Vector2.Distance(player.transform.position, transform.position) > 1.1f)
            {
                rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
            }
        
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.GetChild(0).transform.position, Quaternion.identity);
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == jenisPeluru)
        {
            camShake.animator.SetTrigger("Shake");
            animator.SetTrigger("Kena");
            health--;
            SoundManager.instance.PlayKena(dong);
        }

        if (target.tag == enggakPeluru)
        {
            if(merah)
            {
                speed = speed + 0.1f;
            }
            animator.SetTrigger("EnggakKena");
            SoundManager.instance.PlayKena(tang);
        }

    }

    

}