using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stats : MonoBehaviour 
{
	public Text[] rankText;
	private string[] rankSplit;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (pegastats ());
		StartCoroutine (pegaRank ());
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
			//Debug.Log (r);
		} else {
			Debug.Log ("error " + retorno.error);
		}
	}
	IEnumerator pegaRank()
	{
		WWWForm form = new WWWForm ();

		form.AddField ("action", "pegaRank");


		WWW retorno = new WWW ("http://localhost/MICROCAMP/UnityMySQL.php", form);

		yield return retorno;

		if (retorno.error == null) {
			string r = retorno.text;
			//Debug.Log (r);
			rankSplit = r.Split ('|');

			for (int i = 0; i < 50; i++) {
				rankText[i].text = rankSplit [i];
			}
		} else {
			Debug.Log ("error " + retorno.error);
		}
	}

}
