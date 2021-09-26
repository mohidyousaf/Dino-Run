using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JItterTheCamera : MonoBehaviour
{
[SerializeField] GameObject camera;
[SerializeField] GameObject player;
[SerializeField] int HurdleCollisionCount=0;
[SerializeField] GameObject DebrisPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //camera=GameObject.FindObjectOfType<StressReceiver>();
        camera=GameObject.Find("Main Camera");
    }
    private void OnTriggerEnter()
    {
        Debug.Log("Player Name:"+player.name);
        if(!(player.name=="Brachiosaurus Variant"))
        {
        Debug.Log("i am going to jitter");
            camera.GetComponent<StressReceiver>().InduceStress(0.5607f);
            
        }
        else{
        GameObject smoke = (GameObject)Instantiate(DebrisPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z),transform.rotation);           
        smoke.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(player==null)
        {
            //HurdleCollisionCount=0;
            player=GameObject.FindWithTag("Dino");
        }
    }
}
