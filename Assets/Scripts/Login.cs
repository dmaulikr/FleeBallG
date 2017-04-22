﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine;

public class Login : MonoBehaviour
{
	Gerenciador manager;

	public Text TextoRetorno;
	public InputField inputNickName;
	public InputField inputPassword;
	public string senhaMD5;

	// Use this for initialization
	void Start () 
	{
		manager = this.gameObject.GetComponent<Gerenciador> ();
	}
	public void LogarUsuario ()
	{
		EncryptMd5(inputPassword.text);
	}

	IEnumerator LoginUsuario(string senha)
	{
		WWWForm form = new WWWForm ();

		form.AddField ("action" , "login");
		form.AddField ("nickName" , inputNickName.text);
		form.AddField ("senha" , senha);

		WWW retorno = new WWW ("http://matheussilvabd.esy.es/FleeBall/UnityMySQL.php", form);

		yield return retorno;

		if (retorno.error == null) {
			string r = retorno.text;
			TextoRetorno.text = r;
			Debug.Log (r);

			if (r == "LOGGED") 
			{
				PlayerPrefs.SetString ("nicknamePF", inputNickName.text);
				PlayerPrefs.SetString ("senhaPF", senha);

				manager.logged ();

			}
		}else{
			Debug.Log("error "+retorno.error);
		}
	}
	public void EncryptMd5(string input)
	{
		System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create ();
		byte[] data = md5.ComputeHash (System.Text.Encoding.Default.GetBytes (input));
		System.Text.StringBuilder sbString = new System.Text.StringBuilder ();
		for (int i = 0; i < data.Length; i++)
			sbString.Append (data [i].ToString ("x2"));
		senhaMD5 = sbString.ToString ();
		StartCoroutine (LoginUsuario(senhaMD5));
	}
}