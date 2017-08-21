using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine;

public class Login : MonoBehaviour
{
	Gerenciador manager;

	public Text TextoRetorno;
	public InputField inputEmail;
	public InputField inputPassword;
	public Toggle SaveLogin;

	public string senhaMD5;
	public string  nicknameR;

	public static bool Logar = false;

	// Use this for initialization
	void Start ()
	{
		Debug.Log (PlayerPrefs.GetString ("emailPF"));
		Debug.Log (PlayerPrefs.GetString ("senhaPF"));

		if (PlayerPrefs.GetString ("emailPF") == null && PlayerPrefs.GetString ("senhaPF") == null)
		{
			Debug.Log ("Acontece nada");
		} else {
			inputEmail.text = PlayerPrefs.GetString ("emailPF");
			inputPassword.text = PlayerPrefs.GetString ("senhaPF");
		}

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
		form.AddField ("Email" , inputEmail.text);
		form.AddField ("senha" , senha);

		WWW retorno = new WWW ("http://localhost/MICROCAMP/UnityMySQL.php", form);

		yield return retorno;

		if (retorno.error == null) {
			string r = retorno.text;
			TextoRetorno.text = r;
			Debug.Log (r);

			StartCoroutine (EmailUsuario());

			if (SaveLogin.isOn == true) {
				PlayerPrefs.SetString ("emailPF", inputEmail.text);
				PlayerPrefs.SetString ("senhaPF", inputPassword.text);
			} else{
				Debug.Log ("Não salva nada");
			}
				
			if (r == "LOGGED") 
			{
				manager.logged ();
			}
		}else{
			Debug.Log("error "+retorno.error);
		}
	}
	IEnumerator EmailUsuario()
	{
		WWWForm form = new WWWForm ();

		form.AddField ("action", "profileEmail");
		form.AddField ("email", inputEmail.text);

		WWW retorno = new WWW ("http://localhost/MICROCAMP/UnityMySQL.php", form);

		yield return retorno;

		if (retorno.error == null) {
			string r = retorno.text;
			Debug.Log (r);
		} else {
			Debug.Log ("error " + retorno.error);
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