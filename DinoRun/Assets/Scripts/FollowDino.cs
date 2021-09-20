using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDino : MonoBehaviour
{
    public Transform currentDino;

    void Start()
    {
        currentDino = GameObject.FindWithTag("Dino").transform;
        
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

        Vector3  tempPosition; 

         // compute position
         if(offsetPositionSpace == Space.Self)
         {
            tempPosition = currentDino.TransformPoint(new Vector3 (0,30,-40));
         }
         else
         {
            tempPosition = currentDino.position +  new Vector3 (0,30,-40);
         }

         tempPosition.y = transform.position.y;

         transform.position = tempPosition;

     }

    void changeDino()
    {
        currentDino = GameObject.FindWithTag("Dino").transform;
    }
}
