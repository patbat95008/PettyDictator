using UnityEngine;
using System.Collections;

public class CameraSequence : MonoBehaviour {
    public float speed = 10;
	public int curr_index = 0;

    public GameObject[] waypoints;

	private float dist_thresh = 0.1f;
	// Use this for initialization
	void Start () {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        if(waypoints != null){
			int last = waypoints.Length - 1;
            Vector3 initialPos = waypoints[last].transform.position;
            transform.position = initialPos;
			curr_index = last;
        }
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance(waypoints[curr_index].transform.position, transform.position);
		if(distance > dist_thresh)
			GoToWaypoint(curr_index);
	}
    
    void GoToWaypoint (int index){
		if(waypoints.Length <= index){
            Debug.Log("Sorry, too big");
		}else{
	        float step = speed * Time.deltaTime;
	        Transform target = waypoints[index].transform;
	        
	        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		}
    }
}
