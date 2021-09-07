using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDino : MonoBehaviour
{
    public Vector3 offset = new Vector3 (0,12,-22);

    public GameObject dino;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(dino.transform.position);
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position= dino.transform.position + new Vector3(0,12,-12);
        
    }
}
