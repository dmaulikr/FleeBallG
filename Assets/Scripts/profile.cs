using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class profile : MonoBehaviour 
{
	public Text NickName;
	public Text Email;


	// Use this for initialization
	void Start () 
	{
		StartCoroutine (NickUsuario());
	}
	
	// Update is called once per frame
	void Update () 
	{
		Email.text = PlayerPrefs.GetString ("emailPF");

	}
	IEnumerator NickUsuario()
	{
		WWWForm form = new WWWForm ();

		form.AddField ("action", "profileNickname");
		form.AddField ("email", PlayerPrefs.GetString("emailPF"));

		WWW retorno = new WWW ("http://localhost/MICROCAMP/UnityMySQL.php", form);

		yield return retorno;

		if (retorno.error == null) {
			string r = retorno.text;
			Debug.Log (r);
			NickName.text = r;
		} else {
			Debug.Log ("error " + retorno.error);
		}
	}

}