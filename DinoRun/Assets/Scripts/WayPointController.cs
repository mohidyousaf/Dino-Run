using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WayPointController : MonoBehaviour
{
    public Transform currentDino;
    private List<Transform> waypoints;
    private int wayPointIndex;

    void onEnable()
    {
        waypoints = GetComponentsInChildren<Transform>().ToList();
        waypoints.RemoveAt(0);
        wayPointIndex = 0;
        Debug.Log(waypoints.Count);
        //currentDino = GameObject.FindWithTag("Dino").transform;
    }

    void Start()
    {
        //currentDino = GameObject.FindWithTag("Dino").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (!currentDino){
        //    currentDino = GameObject.FindWithTag("Dino").transform;
        //}

        if (checkInWaypoint())
        {
            Debug.Log("WayPoint Arrived");
            currentDino.rotation = waypoints[wayPointIndex].rotation;
            if (wayPointIndex <= waypoints.Count-2)
            {
                wayPointIndex += 1;
            }
            else 
            {
                reset();
            }
        }
    }

    private bool checkInWaypoint()
    {
        int dis = 10;
        //Transform currentWaypoint = waypoints[wayPointIndex];
        //if ( ( currentWaypoint - currentDino.position ).sqrMagnitude < presetDistance * presetDistance ) // sqrMagnitude, magnitude, Vector3.Distance, whatever your choice is
        if (Vector3.Distance(waypoints[wayPointIndex].position, currentDino.position) <= dis) //insert norm formula here
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
