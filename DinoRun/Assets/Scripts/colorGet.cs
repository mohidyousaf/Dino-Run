using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorGet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Renderer eggColor = this.GetComponent<Renderer>();
    }

    public Color tellColor(GameObject nextDino)
    {
        Renderer dinoCol = nextDino.GetComponent<Renderer>();
        return dinoCol.material.GetColor("_color");
    }
}
