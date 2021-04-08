using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject target;
    private Vector3 posisi;
    public float cameraSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    public bool gtr = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        posisi = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z - 10);
        rb.position = Vector3.Lerp(rb.position, posisi, cameraSpeed * Time.deltaTime);
    }




    public void CameraShake()
    {
        animator.SetTrigger("Shake");
    }
}
