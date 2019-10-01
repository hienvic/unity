using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public float moveForce = 20f;
	public float jumpForce = 600f;
	public float maxVelocity = 4f;
	public int score = 0;

	private bool grounded;

	private Rigidbody2D myBody;
	private Animator anim;
	public int ourHealth;
	public int maxHealth = 100;
	private Scene scene;
	public Sounds sound;


	private void Awake()
	{
		myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		ourHealth = maxHealth;
	}

	// Start is called before the first frame update
	void Start()
	{
		sound = GameObject.FindGameObjectWithTag("Sounds").GetComponent<Sounds>();

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		PlayerWalkKeyBoard();
	}

	void PlayerWalkKeyBoard()
	{
		float forceX = 0f;
		float forceY = 0f;

		float vel = Mathf.Abs(myBody.velocity.x);
		float h = Input.GetAxisRaw("Horizontal");

		if (h > 0)
		{
			if (vel < maxVelocity)
			{
				if (grounded)
				{
					forceX = moveForce;
				}
				else
				{
					forceX = moveForce * 1.1f;
				}
			}


			Vector3 scale = transform.localScale;
			scale.x = 1f;
			transform.localScale = scale;

			anim.SetBool("Walk", true);
		} /* else if (h < 0)
		{
			if (vel < maxVelocity)
			{
				if (grounded)
				{
					forceX = -moveForce;
				}
				else
				{
					forceX = -moveForce * 1.1f;
				}
			}

			Vector3 scale = transform.localScale;
			scale.x = -1f;
			transform.localScale = scale;

			anim.SetBool("Walk", true);
		} */
		else if (h == 0)
		{
			anim.SetBool("Walk", false);
		}


		if (Input.GetKey(KeyCode.Space))
		{
			if (grounded)
			{
				grounded = false;
				forceY = jumpForce;
			}
		}
		if (transform.position.y < -4f)
		{
			Application.LoadLevel("EndGame");
		}
		if (ourHealth == 0) {
			Application.LoadLevel("EndGame");
		}

		myBody.AddForce(new Vector2(forceX, forceY));
	}

	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "Ground")
		{
			grounded = true;
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Cactus"))
		{
			if (ourHealth > 0)
			{
				sound.PlaySound("die");
				ourHealth=ourHealth-10;
			}

		}
		if (collision.CompareTag("Bat"))
		{
			sound.PlaySound("die");
			ourHealth = 0;
		}

		if (collision.CompareTag("Diamond"))
		{
			sound.PlaySound("checkPoint");
			score = score + 1;
			Destroy(collision.gameObject);
		}
		if (collision.CompareTag("Red Diamond"))
		{
			sound.PlaySound("checkPoint");
			score = score + 1;
			Destroy(collision.gameObject);
			Application.LoadLevel("WinGame");
		}
	}
}