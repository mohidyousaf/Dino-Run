using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class WayPointController : MonoBehaviour
{
    public Transform currentDino;
    public Swipe dinoS;
    public Transform camera;

    public float dis = 20;


    public bool isPassed;

    float xdis, zdis;

    void Start()
    {
        currentDino = GameObject.FindWithTag("Dino").transform;
        zdis = 100;
        xdis = 100;
        isPassed = false;
    
    }

    // Update is called once per frame
    void Update()
    {
        if (!currentDino){
            currentDino = GameObject.FindWithTag("Dino").transform;
        }
        
        if (!isPassed)
        {
            if (checkInWaypoint())
            {

                float speed = 40;

                currentDino.rotation = Quaternion.Lerp (currentDino.rotation, transform.rotation, Time.time * speed);
                camera.rotation = Quaternion.Lerp (camera.rotation, transform.rotation, Time.time * speed);


                isPassed = true;

                dinoS.changeDir();

                reset_dis();

            }
        }
    }


    private bool checkInWaypoint()
    {

        float zdis = Math.Abs(transform.position.z - currentDino.position.z);
        float xdis = Math.Abs(transform.position.x - currentDino.position.x);
        
        if (Vector3.Distance(transform.position, currentDino.position) <= dis)
        {
            if (dinoS.movingVertical)
            {
                Debug.Log("inside vertical");
                if ( (dinoS.isRight &&  zdis <= 19) || 
                (dinoS.isMiddle && zdis <= 10) ||
                (dinoS.isLeft && zdis <= 5))
                {
                    return true;
                }
            }
            
            else{
                Debug.Log("inside horizontal");
                if ((dinoS.isRight && xdis <= 4) || 
                (dinoS.isMiddle && xdis <= 12) ||
                (dinoS.isLeft && xdis <= 19))
                {
                    Debug.Log("xdis:" + xdis);
                    return true;
                }
            }
        }
        return false;
    }


    void reset_dis()
    {
        zdis = 100;
        xdis = 100;
    }

    void changeDino()
    {
        currentDino = GameObject.FindWithTag("Dino").transform;
    }

}

/* Reference Points for Level 1:

Path width: around 24

Reference Points for turning and keeping lanes same:

1. Going from  Vertical to Horizontal:
wp: "position":{"x":-42.20000076293945,"y":0.0,"z":9.899999618530274}
right: "position":{"x":-39.099998474121097,"y":0.0,"z":-10.800000190734864}
middle: "position":{"x":-39.099998474121097,"y":0.0,"z":-0.30000001192092898}
left: "position":{"x":-39.099998474121097,"y":0.0,"z":7.599999904632568}

1. Going from  Horizontal to Vertical:
wp: "position":{"x":201.60000610351563,"y":0.0,"z":-1.600000023841858}
right: "position":{"x":197.0,"y":-0.012160777114331723,"z":0.20000000298023225}
middle: "position":{"x":189.60000610351563,"y":-0.012160777114331723,"z":0.4000000059604645}
left: "position":{"x":182.39999389648438,"y":-3.799999952316284,"z":0.30000001192092898}
*/