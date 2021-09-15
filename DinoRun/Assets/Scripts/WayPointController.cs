using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WayPointController : MonoBehaviour
{
    public Transform currentDino;
    //private List<Transform> waypoints;
    public GameObject[] waypoints;
    private int wayPointIndex;

    void onEnable()
    {
        //waypoints = GetComponentsInChildren<Transform>().ToList();
        //waypoints.RemoveAt(0);
        wayPointIndex = 0;
        
        //currentDino = GameObject.FindWithTag("Dino").transform;
    }

    void Start()
    {
        //Debug.Log("No. of objects are:", waypoints.Count);
        currentDino = GameObject.FindWithTag("Dino").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!currentDino){
            currentDino = GameObject.FindWithTag("Dino").transform;
        }
        
        if (wayPointIndex <= waypoints.Length-1)
        {
            if (checkInWaypoint())
            {
                //Debug.Log("WayPoint Arrived");
                //transform.Rotate()
                // currentDino.rotation = waypoints[wayPointIndex].transform.rotation;
                //Debug.Log("came here");
                //Vector3 rot = waypoints[wayPointIndex].transform.rotation ; 
                //Vector3 dinoRot = currentDino.rotation;
                float speed = 10;
                //currentDino.rotation = Quaternion.RotateTowards ( currentDino.rotation , waypoints[wayPointIndex].transform.rotation , Time.deltaTime*speed);
                currentDino.rotation = Quaternion.Slerp (currentDino.rotation, waypoints[wayPointIndex].transform.rotation , Time.deltaTime * 40);
                Debug.Log("index is "+ wayPointIndex);
                wayPointIndex += 1;
                        // Determine which direction to rotate towards
        /*
        Vector3 targetDirection = waypoints[wayPointIndex].transform.position - currentDino.position;

        // The step size is equal to speed times frame time.
        float singleStep = 10 * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(currentDino.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(currentDino.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        currentDino.rotation = Quaternion.LookRotation(newDirection);*/


            }
        }
        else 
        {
            reset();
        }
    }

    private bool checkInWaypoint()
    {
        int dis = 10;
        //Transform currentWaypoint = waypoints[wayPointIndex];
        //if ( ( currentWaypoint - currentDino.position ).sqrMagnitude < presetDistance * presetDistance ) // sqrMagnitude, magnitude, Vector3.Distance, whatever your choice is
        //Debug.Log(Vector3.Distance(waypoints[wayPointIndex].transform.position, currentDino.position));
        if (Vector3.Distance(waypoints[wayPointIndex].transform.position, currentDino.position) <= dis) //insert norm formula here
        {
            return true;
        }
        return false;
    }

    private void reset()
    {
        wayPointIndex = 0;
    }

    void changeDino()
    {
        currentDino = GameObject.FindWithTag("Dino").transform;
    }

    // Update is called once per frame
}
