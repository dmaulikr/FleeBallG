using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Resgister : MonoBehaviour 
{
	Gerenciador manager;

	public Text TextoRetorno;
	public InputField inputNickName;
	public GameObject panel;
	private string typeAccount;

	// Use this for initialization
	void Start () 
	{
		typeAccount = "conventional";
		manager = this.gameObject.GetComponent<Gerenciador> ();
	}

	IEnumerator RegisterUser()
	{
		WWWForm form = new WWWForm ();

		form.AddField ("action" , "register");
		form.AddField ("nickName" , inputNickName.text);
		form.AddField ("tipoConta", typeAccount);

		WWW retorno = new WWW ("http://localhost/MICROCAMP/UnityMySQL.php", form);

		yield return retorno;

		if (retorno.error == null) {
			string r = retorno.text;
			TextoRetorno.text = r;
			Debug.Log (r);

			if (r == "User successfully registered!") 
			{
				PlayerPrefs.SetString ("nickNamePF", inputNickName.text);
				manager.logged ();
			}

		}else{
			Debug.Log("error "+retorno.error);
		}
	}
	public void EnviarDados()
	{
		StartCoroutine (RegisterUser ());
	}
}

