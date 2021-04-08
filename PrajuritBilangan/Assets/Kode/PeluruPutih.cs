using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeluruPutih : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    void Start()
    {
        dir = GameObject.Find("Dir").transform.position;
        transform.position = GameObject.Find("FirePoint").transform.position;
        Destroy(gameObject, 3);
        transform.eulerAngles = new Vector3(0, 0, GameObject.Find("PlayerFix").transform.eulerAngles.z);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
    }

    
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Musuh" || target.tag == "Musuh2")
        {
            Destroy(gameObject);
        }
    }
}
