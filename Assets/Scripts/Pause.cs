using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause : MonoBehaviour 
{
	public GameObject BlackScreen;
	public GameObject timeText;
	public GameObject time;

	public Button pause;
	public Button resume;
	public Button restart;
	//public Button exit;

	// Use this for initialization
	void Start () 
	{
		Button btn = pause.GetComponent<Button> ();
		pause.onClick.AddListener (PauseClick);

		Button rsm = resume.GetComponent<Button> ();
		resume.onClick.AddListener (ResumeClick);

		Button rst = restart.GetComponent<Button> ();
		restart.onClick.AddListener (RestartGame);

		//Button ext = exit.GetComponent<Button> ();
		//exit.onClick.AddListener (ExitGame);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void PauseClick ()
	{
		PauseGame ();
	}
	void ResumeClick ()
	{	
		Despause ();
	}
	void PauseGame ()
	{
		BlackScreen.SetActive (true);
		Time.timeScale = 0;
		timeText.SetActive (false);
		time.SetActive (false);
	}
	void Despause ()
	{
		BlackScreen.SetActive (false);
		Time.timeScale = 1;
		timeText.SetActive (true);
		time.SetActive (true);
	}
	void RestartGame()
	{
		Application.LoadLevel (Application.loadedLevel);
		Time.timeScale = 1;
	}
	void ExitGame ()
	{
		//Application.Quit ();
	}
}
