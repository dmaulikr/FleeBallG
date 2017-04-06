using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class BestScore : MonoBehaviour 
{
	Gerenciador manager;

	public float bestScore;
	public float record;
	//public Text TextoRetorno;
	public Text UIText;
	// Use this for initialization
	void Start ()
	{
		manager = this.gameObject.GetComponent<Gerenciador> ();
		StartCoroutine (EnviarDados ());
		cronometer.time = 0;
		//cronometer.TempoInteiro = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		bestScore = PlayerPrefs.GetFloat("bestScore");
		UIText.text = bestScore.ToString("0");

		StartCoroutine (EnviarDados ());
	}
	IEnumerator EnviarDados()
	{
		WWWForm form = new WWWForm ();

		form.AddField ("action" , "BestScore");
		form.AddField ("nickName", PlayerPrefs.GetString ("nicknamePF"));
		form.AddField ("senha", PlayerPrefs.GetString ("senhaPF"));
		form.AddField ("bestscorePlayer" , bestScore.ToString());

		WWW retorno = new WWW ("http://localhost/MICROCAMP/UnityMySQL.php", form);

		yield return retorno;

		if (retorno.error == null) {
			string r = retorno.text;
			//TextoRetorno.text = r;
			Debug.Log (r);
		}else{
			Debug.Log("error "+retorno.error);
		}
	}
}
