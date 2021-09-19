using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    float walkSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 forward = transform.forward;
        //forwardY = transform.position
        //transform.position += 
        //Vector3 move = Vector3.forward * new Vector3(1f,0f,1f) + new Vector3(0f, transform.position.y, 0f);
        //Vector3 move = transform.forward;
        //move.y = yPos;
        //transform.Translate(transform.forward * 10 * Time.deltaTime, Space.World);
        float walkSpeed = 10;
        Vector3 newCameraPosition = transform.position + transform.forward * walkSpeed * Time.deltaTime;  
        transform.position = new Vector3(newCameraPosition.x,transform.position.y,newCameraPosition.z);  
        //transform.position += new Vector3( transform.position.x, transform.position.y,  transform.position.z + 1f,);
    }
}
