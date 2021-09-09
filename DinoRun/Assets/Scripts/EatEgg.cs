using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatEgg : MonoBehaviour
{
    void Start()
    {
        
    }
    
    
    private void OnCollisionEnter(Collision col)
    {
       
        if (col.gameObject.CompareTag("Dino"))
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update

}
