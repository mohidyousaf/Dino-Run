using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
private void OnCollisionEnter(Collision target)
{
Debug.Log("Hi Collision");
Debug.Log(target.gameObject.name);
}
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am running Script");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
