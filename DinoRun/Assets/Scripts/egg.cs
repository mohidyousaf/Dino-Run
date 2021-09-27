using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egg : MonoBehaviour
{
    [SerializeField]  public GameObject nextDino;
    //[SerializeField] private material eggColor;
    [SerializeField] private Renderer eggColor;
   
    [SerializeField]  public Color col = new Color32(255, 213, 112, 255);
    [SerializeField]  public bool Flying;

    void Awake()
    {
        eggColor.material.color = col;
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
