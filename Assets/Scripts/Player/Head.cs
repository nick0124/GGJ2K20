using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
	public PlayerController playerController;

	public float chilloutTime;
	private float chilloutTimer;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (chilloutTimer > 0) {
			chilloutTimer -= Time.deltaTime;
			playerController.enabled = false;
		} else {
			playerController.enabled = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.transform.name != gameObject.name && collision.GetComponent<Rigidbody2D>() != null) {
			if(collision.GetComponent<Rigidbody2D>().velocity.y < -5) {
				chilloutTimer = chilloutTime;
			}
			Debug.Log("collide " + collision.GetComponent<Rigidbody2D>().velocity.y);
		}
	}
}
