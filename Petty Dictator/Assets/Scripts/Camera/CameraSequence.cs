using UnityEngine;
using System.Collections;

public class CameraSequence : MonoBehaviour {
    public float speed = 10;
    public GameObject[] waypoints;

	// Use this for initialization
	void Start () {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        if(waypoints != null){
            Vector3 initialPos = waypoints[0].transform.position;
            transform.position = initialPos;
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    
    void GoToWaypoint (int index){
        if(waypoints.Length <= index)
            Debug.Log("Sorry, too big");
        float step = speed * Time.deltaTime;
        Transform target = waypoints[index].transform;
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        
    }
}
