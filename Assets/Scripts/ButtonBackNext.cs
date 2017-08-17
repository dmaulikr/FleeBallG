using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBackNext : MonoBehaviour 
{
	private int pag;
	public GameObject Ranking1;
	public GameObject Ranking2;
	public GameObject Ranking3;
	public GameObject Ranking4;
	public GameObject Ranking5;

	public Button buttonNext;
	public Button buttonBack;

	// Use this for initialization
	void Start ()
	{
		Button btn = buttonNext.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClickNext);

		Button btn2 = buttonBack.GetComponent<Button>(); 
		btn.onClick.AddListener (TaskOnClickBack);

		pag = 1;

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void TaskOnClickNext ()
	{
		pag += 1;
		if (pag == 1) 
		{
			pag1 ();
		}
		if (pag == 2) 
		{
			pag2 ();
		}
		if (pag == 3) 
		{
			pag3 ();
		}
		if (pag == 4)
		{
			pag4 ();
		}
		if (pag == 5) 
		{
			pag5 ();
		}
		if (pag == 5) 
		{
			pag = 5;
		}
	}
	void TaskOnClickBack ()
	{
		pag -= 1;
		if (pag == 1) {
			pag1 ();
		}
		if (pag == 2) {
			pag2 ();
		}
		if (pag == 3) {
			pag3 ();
		}
		if (pag == 4) {
			pag4 ();
		}
		if (pag == 5) {
			pag5 ();
		}
		if (pag == 1) 
		{
			pag = 1;
		}
	}

	public void pag1 ()
	{
		Ranking1.gameObject.active = true;
		Ranking2.gameObject.active = false;
		Ranking3.gameObject.active = false;
		Ranking4.gameObject.active = false;
		Ranking5.gameObject.active = false;
	}
	public void pag2 ()
	{
		Ranking1.gameObject.active = false;
		Ranking2.gameObject.active = true;
		Ranking3.gameObject.active = false;
		Ranking4.gameObject.active = false;
		Ranking5.gameObject.active = false;
	}
	public void pag3 ()
	{
		Ranking1.gameObject.active = false;
		Ranking2.gameObject.active = false;
		Ranking3.gameObject.active = true;
		Ranking4.gameObject.active = false;
		Ranking5.gameObject.active = false;
	}
	public void pag4 ()
	{
		Ranking1.gameObject.active = false;
		Ranking2.gameObject.active = false;
		Ranking3.gameObject.active = false;
		Ranking4.gameObject.active = true;
		Ranking5.gameObject.active = false;
	}
	public void pag5 ()
	{
		Ranking1.gameObject.active = false;
		Ranking2.gameObject.active = false;
		Ranking3.gameObject.active = false;
		Ranking4.gameObject.active = false;
		Ranking5.gameObject.active = true;
	}
}
