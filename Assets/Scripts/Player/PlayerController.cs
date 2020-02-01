using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rb;

	[Header("Movement")]
	public float movementSpeed;
	public float jumpForce;

	[Header("Controlls")]
	public KeyCode moveLeft;
	public KeyCode moveRight;
	public KeyCode moveJump;

	private int collide;

    // Start is called before the first frame update
    void Start()
    {
		rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(moveRight)) {
			rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
		}
		if (Input.GetKey(moveLeft)) {
			rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
		}

		if (Input.GetKeyDown(moveJump) && collide > 0) {
			rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.transform.name != gameObject.name) {
			collide++;
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.transform.name != gameObject.name) {
			collide--;
		}
	}
}
