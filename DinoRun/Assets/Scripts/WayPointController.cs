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
        
        if (wayPointIndex <= waypoints.Length-2)
        {
            if (checkInWaypoint())
            {
                //Debug.Log("WayPoint Arrived");
                //transform.Rotate()
                currentDino.rotation = waypoints[wayPointIndex].transform.rotation;
                wayPointIndex += 1;
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
