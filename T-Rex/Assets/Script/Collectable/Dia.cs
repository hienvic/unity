using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dia : MonoBehaviour
{

	private Rigidbody2D myBody;
	private Animator anim;

	private void Awake()
	{
		myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
}
