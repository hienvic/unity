using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
	[SerializeField]
	private GameObject gameOverPanel;
	public static GamePlayController instance;
	public Player player;
	private void Awake()
	{
		MakeInstance();
	}
	void MakeInstance()
	{
		if (instance == null)
		{
			instance = this;
		}
	}
	public void RestartButton()
	{
		gameOverPanel.SetActive(false);
		Application.LoadLevel("MainMenu");
	}
	public void DiedShowPanel()
	{
		if (player.ourHealth <= 0)
		{
			gameOverPanel.SetActive(true);
		}
	} 
}
