using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeluruMusuh : MonoBehaviour
{
	public float moveSpeed;
	public Rigidbody2D rb;
	public Vector2 moveDirection;
	public GameObject target;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.Find("PlayerFix");
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		Destroy(gameObject, 3f);
	}


	void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
