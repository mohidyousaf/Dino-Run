using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDino : MonoBehaviour
{
    public Transform currentDino;
    public Vector3 offset = new Vector3 (0,12,-22);

    //public GameObject dino;
    // Start is called before the first frame update
    void Start()
    {
        currentDino = GameObject.FindWithTag("Dino").transform;
        //Debug.Log(dino.transform.position);
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!currentDino){
            changeDino();
        }
        transform.position = currentDino.position + new Vector3(0,12,-12);
        
    }

    void changeDino()
    {
        currentDino = GameObject.FindWithTag("Dino").transform;
    }
}
