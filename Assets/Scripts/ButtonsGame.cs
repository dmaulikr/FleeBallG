using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonsGame : MonoBehaviour 
{
	//public string scene;
	public Button buttonsGame;
	public int sceneRandom;

	// Use this for initialization
	void Start () 
	{
		Button btn = buttonsGame.GetComponent<Button> ();
		buttonsGame.onClick.AddListener (TaskOnClick);
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
	void TaskOnClick ()
	{
		//Application.LoadLevel (scene);
	}

	public void startGame()
	{
		Application.LoadLevel ("menuSelect");
	}

	public void basket()
	{
		Application.LoadLevel ("Basket");
	}
	public void Futsal()
	{
		Application.LoadLevel ("Futsal");
	}
	public void PingPong()
	{
		Application.LoadLevel ("PingPong");
	}
	public void soccer()
	{
		Application.LoadLevel ("soccer");
	}
	public void Tennis()
	{
		Application.LoadLevel ("Tenis");
	}
	public void Voley()
	{
		Application.LoadLevel ("Voley");
	}

	public void random()
	{
		sceneRandom = Random.Range (1, 6);

		if (sceneRandom == 1) 
		{
			Application.LoadLevel ("Basket");
		}
		if (sceneRandom == 2) 
		{
			Application.LoadLevel ("Futsal");
		}
		if (sceneRandom == 3) 
		{
			Application.LoadLevel ("PingPong");
		}
		if (sceneRandom == 4) 
		{
			Application.LoadLevel ("soccer");
		}
		if (sceneRandom == 5) 
		{
			Application.LoadLevel ("Tenis");
		}
		if (sceneRandom == 6) 
		{
			Application.LoadLevel ("Voley");
		}
	}

}