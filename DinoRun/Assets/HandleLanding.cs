using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLanding : MonoBehaviour
{
    private void OnTriggerEnter(Collider target)
    {
       /* Debug.Log(target.gameObject.tag);
        if(target.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy should die");
            Destroy(target.gameObject);
        }*/
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
