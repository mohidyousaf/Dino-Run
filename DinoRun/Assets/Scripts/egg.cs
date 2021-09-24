using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egg : MonoBehaviour
{
    public GameObject nextDino;
    //[SerializeField] private material eggColor;
    [SerializeField] private Renderer eggColor;
    //colorGet dinoCol;
    public bool Flying;

    void Awake()
    {
        //Renderer eggColor = this.GetComponent<Renderer>();
        //Renderer dinoCol = nextDino.GetComponent<Renderer>();
        eggColor.material.color = new Color32(112,95,75,255);
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
