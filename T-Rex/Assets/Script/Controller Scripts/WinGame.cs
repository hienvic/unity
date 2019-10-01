using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
	// Start is called before the first frame update
	public void Replay()
	{
		Application.LoadLevel("MainMenu");
	}
}
