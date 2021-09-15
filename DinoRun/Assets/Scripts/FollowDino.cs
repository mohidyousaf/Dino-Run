using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDino : MonoBehaviour
{
    public Transform currentDino;
   

    //public GameObject dino;
    // Start is called before the first frame update
    void Start()
    {
        currentDino = GameObject.FindWithTag("Dino").transform;
        //Debug.Log(dino.transform.position);
        
    }
    [SerializeField]
     private Vector3 offsetPosition;
 
     [SerializeField]
     private Space offsetPositionSpace = Space.Self;
 
     [SerializeField]
     private bool lookAt = true;
 
     private void Update()
     {
         Refresh();
     }

      public void Refresh()
     {
         if(currentDino == null)
         {
            changeDino();
            Debug.LogWarning("Missing target ref !", this);
 
            return;
         }
 
         // compute position
         if(offsetPositionSpace == Space.Self)
         {
             transform.position = currentDino.TransformPoint(new Vector3 (0,30,-40));
         }
         else
         {
             transform.position = currentDino.position +  new Vector3 (0,30,-40);
         }
 
         // compute rotation
         if(lookAt)
         {
             transform.LookAt(currentDino);
         }
         else
         {
             transform.rotation = currentDino.rotation;
         }
     }

    // Update is called once per frame
    // void LateUpdate()
    // {
    //     if (!currentDino){
    //         changeDino();
    //     }
        

        
    //     transform.position = currentDino.position + new Vector3(0,12,0);
    //     transform.rotation = currentDino.rotation ;
    //     transform.rotation *= Quaternion.Euler(new Vector3(15, 0,0));

        
    //     Debug.Log("the rotation is "+ transform.rotation);
    // }

    void changeDino()
    {
        currentDino = GameObject.FindWithTag("Dino").transform;
    }
}
