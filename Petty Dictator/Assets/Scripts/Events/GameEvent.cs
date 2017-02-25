using UnityEngine;
using System.Collections;

public class GameEvent : MonoBehaviour {
	public string key;
	public string title;
	public string briefing;

	public ArrayList choice_a_good = new ArrayList();
	public ArrayList choice_a_bad = new ArrayList();
	public string choice_a_link, choice_a_title;



	public ArrayList choice_b_good = new ArrayList();
	public ArrayList choice_b_bad = new ArrayList();
	public string choice_b_link, choice_b_title;

	/*public GameEvent (string key, string title, 
		string briefing, Choice choice_a_good, Choice choice_b){
		this.key = key;
		this.title = title;
		this.briefing = briefing;

		this.choice_a_good = choice_a_good;
		this.choice_b = choice_b;
	}*/
}
