using UnityEngine;
using System.Collections;

public class UI_Control : MonoBehaviour {
	public GameObject ui, briefing, debate, office;
	public position player_pos;
	public enum position {Briefing, Debate, Office};

	private GameObject go_cam;
	private CameraSequence cam_seq;
	private GameObject[] ui_sequence;

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
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Next () {
		if(cam_seq.curr_index > 0){
			cam_seq.curr_index --;

			player_pos = changeUI(player_pos, player_pos + 1);
		}else{
			cam_seq.curr_index = cam_seq.waypoints.Length - 1;
			player_pos = changeUI(player_pos, 0);
		}
	}

	private position changeUI(position pos1, position pos2){
		ui_sequence[(int)pos1].SetActive(false);
		ui_sequence[(int)pos2].SetActive(true);
		return pos2;
	}
}
