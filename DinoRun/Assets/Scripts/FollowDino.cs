using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDino : MonoBehaviour
{
    public Transform currentDino;
     Vector3  tempPosition; 

    void Start()
    {
        currentDino = GameObject.FindWithTag("Dino").transform;
        // transform.position = currentDino.position + new Vector3(-41,15,-25);
        // tempPosition.y = transform.position.y;
        
    }
    [SerializeField]
     private Vector3 offsetPosition;
 
    //  [SerializeField]
    //  private Space offsetPositionSpace = Space.Self;
 
    //  [SerializeField]
    //  private bool lookAt = true;

    
 
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

       

       
        if (currentDino.name == "Brachiosaurus Variant"){
    
            tempPosition = currentDino.position +  new Vector3 (0,15,0)+ transform.forward * -30;
           
        }
            
        else if (currentDino.name == "Velociraptor(Clone)"){
             tempPosition = currentDino.position +  new Vector3 (0,3,0)+ transform.forward * -12;
            ;
        }
        

        else if (currentDino.name == "Pachycephalosaurus(Clone)"){
            tempPosition = currentDino.position +  new Vector3 (0,4,0)+ transform.forward * -10;
            
        }

        else if (currentDino.name == "Pteranodon(Clone)"){
            tempPosition = currentDino.position +  new Vector3 (0,2,0)+ transform.forward * -15;
            
        }


        
        else{
            tempPosition = currentDino.position +  new Vector3 (0,10,0)+ transform.forward * -20;
        }
        

         

         transform.position = tempPosition;

     }

    void changeDino()
    {
        currentDino = GameObject.FindWithTag("Dino").transform;
    }
}
