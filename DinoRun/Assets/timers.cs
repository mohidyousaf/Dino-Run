using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitsForTime(2.1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator waitsForTime(float seconds)
    {
        Debug.Log("waiting function()");
        yield return new WaitForSeconds(seconds);
        Debug.Log("Yamaha Motorcycle");
    }
}
