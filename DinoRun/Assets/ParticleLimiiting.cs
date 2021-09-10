using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLimiiting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator destroyer()
    {
        Debug.Log("waiting function()");
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        Debug.Log("Yamaha Motorcycle");
    }
}
