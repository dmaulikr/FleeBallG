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
	//public Text bestScoreText;
	public static Login instance;
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
		//bestScore = PlayerPrefs.GetFloat("bestScore");

		StartCoroutine (EnviarDados ());
	}
	IEnumerator EnviarDados()
	{
		WWWForm form = new WWWForm ();

		form.AddField ("action" , "BestScore");
		form.AddField ("email", PlayerPrefs.GetString("emailPF"));
		form.AddField ("bestscorePlayer" , cronometer.record.ToString());

		WWW retorno = new WWW ("http://localhost/MICROCAMP/UnityMySQL.php", form);

		yield return retorno;

		if (retorno.error == null) {
			string r = retorno.text;
			//Debug.Log (r);
		}else{
			Debug.Log("error "+retorno.error);
		}
	}
}
