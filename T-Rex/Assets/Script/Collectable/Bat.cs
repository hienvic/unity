using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
	// Start is called before the first frame update
	private Rigidbody2D myBody;
	private Animator anim;

	private void Awake()
	{
		myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
}
