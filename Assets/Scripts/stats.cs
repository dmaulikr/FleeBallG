using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stats : MonoBehaviour 
{
	//public Text[] rankText;
	//public Text namePlayer;
	//public Text Record;
	public Text BestScoreStats;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (pegastats ());
	}
	
	// Update is called once per frame
	public void retornar()
	{
		
	}
	IEnumerator pegastats()
	{
		WWWForm form = new WWWForm ();

		form.AddField ("action", "PegaStats");
		form.AddField ("nickName", PlayerPrefs.GetString ("nicknamePF"));
		form.AddField ("senha", PlayerPrefs.GetString ("senhaPF"));

		WWW retorno = new WWW ("http://localhost/MICROCAMP/UnityMySQL.php", form);

		yield return retorno;

		if (retorno.error == null) {
			string r = retorno.text;
			BestScoreStats.text = r;
			Debug.Log (r);
		} else {
			Debug.Log ("error " + retorno.error);
		}
	}
}
