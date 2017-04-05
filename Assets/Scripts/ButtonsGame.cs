using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonsGame : MonoBehaviour 
{
	public string scene;
	public Button buttonsGame;
	
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
		Application.LoadLevel (scene);
	}
}
