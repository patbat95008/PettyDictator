using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class UI_Control : MonoBehaviour {
	public GameObject ui, briefing, debate, office;
	public position player_pos;
	public enum position {Briefing, Debate, Office};

	private GameObject go_cam;
	private CameraSequence cam_seq;
	private GameObject[] ui_sequence;
	private GameObject brief_a, brief_b, brief_c;
	private GameObject briefing_text;

	void Start () {
		//Load objects
		ui = GameObject.Find("UI");
		briefing = GameObject.Find("Briefing_screen");
		debate = GameObject.Find("Debate_screen");
		office = GameObject.Find("Office_screen");

		player_pos = position.Briefing;

		//Load this last!
		ui_sequence = new GameObject[] {briefing, debate, office};

		go_cam = GameObject.Find("Main Camera");
		cam_seq = go_cam.GetComponent<CameraSequence>();

		//Set up first screen
		briefing.SetActive(true);

		briefing_text = GameObject.Find("Briefing_text");
		briefing_text.SetActive(false);
	}

	//DEBUG: go to the next screen
	public void Next () {
		if(cam_seq.curr_index > 0){
			cam_seq.curr_index --;

			player_pos = changeUI(player_pos, player_pos + 1);
		}else{
			cam_seq.curr_index = cam_seq.waypoints.Length - 1;
			player_pos = changeUI(player_pos, 0);
		}
	}

	//Displays briefing
	//Takes an int:
	//0 - event A	 1 - event B	 2 - event C
	public void Briefing_click (int select){
		string text;
		GameManager manager_script = gameObject.GetComponent<GameManager>();

		if(select == 0)
			text = manager_script.eventA.GetComponent<GameEvent>().briefing;
		else
			text = "404 - No Briefing Found";

		//Turn off all buttons
		buttonSet(false);
		//Set the text and display it
		briefing_text.transform.GetComponentInChildren<Text>().text = text;
		briefing_text.SetActive(true);

	}

	private position changeUI(position pos1, position pos2){
		ui_sequence[(int)pos1].SetActive(false);
		ui_sequence[(int)pos2].SetActive(true);
		buttonSet(true);
		return pos2;
	}

	private void buttonSet(bool onOff){
		//Turn off the buttons
		foreach(GameObject button in GameObject.FindGameObjectsWithTag("Button"))
			button.SetActive(onOff);
	}
}
