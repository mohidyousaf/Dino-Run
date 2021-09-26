using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEggs : MonoBehaviour
{
[SerializeField] GameObject eggsFly;
    // Start is called before the first frame update
    float Yvalue=0.0f;
    void Start()
    {
        eggsFly=GameObject.Find("Modifiers");
        Yvalue=eggsFly.transform.position.y;
        eggsFly.transform.position=new Vector3(eggsFly.transform.position.x,transform.position.y,eggsFly.transform.position.z);
    }
    void OnDestroy()
    {
        eggsFly.transform.position=new Vector3(eggsFly.transform.position.x,Yvalue,eggsFly.transform.position.z);
        //eggsFly.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
