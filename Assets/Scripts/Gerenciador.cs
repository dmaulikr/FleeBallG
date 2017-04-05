using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Gerenciador : MonoBehaviour 
{
	public GameObject canvasLogin;
	public GameObject CanvasRegistro;

	// Use this for initialization
	void Start () 
	{
		canvasLogin.SetActive (true);
		CanvasRegistro.SetActive (false);
	}

	public void registrar()
	{
		canvasLogin.SetActive (false);
		CanvasRegistro.SetActive (true);
	}
	public void retornarLogin()
	{
		canvasLogin.SetActive (true);
		CanvasRegistro.SetActive (false);
	}
	public void logged()
	{
		Application.LoadLevel ("menu");
	}

}