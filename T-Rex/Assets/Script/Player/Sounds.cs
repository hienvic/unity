using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
	public AudioClip checkPoint, die, jump;
	public AudioSource adisrc;
    // Start is called before the first frame update
    void Start()
    {
		checkPoint = Resources.Load<AudioClip>("checkPoint");
		die = Resources.Load<AudioClip>("die");
		jump = Resources.Load<AudioClip>("jump");
		adisrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void PlaySound(string clip) {
		switch(clip)
		{
			case "checkPoint":
				adisrc.clip = checkPoint;
				adisrc.PlayOneShot(checkPoint, 0.6f);
				break;
			case "die":
				adisrc.clip = checkPoint;
				adisrc.PlayOneShot(die, 1f);
				break;
			case "jump":
				adisrc.clip = checkPoint;
				adisrc.PlayOneShot(jump, 1f);
				break;
		}
	}
}
