using UnityEngine;
using System.Collections;

public class Choice : MonoBehaviour {
	public ArrayList good_points;
	public ArrayList bad_points;

	public GameEvent result;
	private string result_key;

	public Choice(ArrayList good_p, ArrayList bad_p, string result_key){
		this.good_points = good_p;
		this.bad_points = bad_p;
		this.result_key = result_key;

		//this.result = GameObject.Find(result_key);
	}
}
