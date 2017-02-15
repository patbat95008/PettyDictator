using UnityEngine;
using System.Collections;

public class NextScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Next () {
		GameObject go_cam = GameObject.Find("Main Camera");
		CameraSequence cam_seq = go_cam.GetComponent<CameraSequence>();

		if(cam_seq.curr_index > 0)
			cam_seq.curr_index --;
		else
			cam_seq.curr_index = cam_seq.waypoints.Length - 1;
	}
}
