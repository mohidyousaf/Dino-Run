using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLanding : MonoBehaviour
{
    [SerializeField] GameObject EnemyDinosaur;
    private Rigidbody rb;
    [SerializeField] GameObject SmokePrefab;
    private void OnTriggerEnter(Collider target)
    {
        if(target.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("pakistan");
            

        }
        Debug.Log("pakistan");
        //EnemyDinosaur.GetComponent<Rigidbody>().isKinematic=true;
        //EnemyDinosaur.GetComponent<Rigidbody>().useGravity=false;
        StartCoroutine(delayActivity());
        //rb.isKinematic=true;
        ///rb.useGravity=false;
        //Debug.Log("hi amjad");
    }
    IEnumerator delayActivity()
    {
        yield return (new WaitForSeconds(2.0f)); 
        Debug.Log("delay Activity");
        GameObject smoke = (GameObject)Instantiate(SmokePrefab, new Vector3(EnemyDinosaur.transform.position.x, EnemyDinosaur.transform.position.y, EnemyDinosaur.transform.position.z), Quaternion.identity);
        smoke.SetActive(true);
        smoke = (GameObject)Instantiate(SmokePrefab, new Vector3(EnemyDinosaur.transform.position.x, EnemyDinosaur.transform.position.y + 2.5f, EnemyDinosaur.transform.position.z), Quaternion.identity);
        smoke.SetActive(true);
        smoke = (GameObject)Instantiate(SmokePrefab, new Vector3(EnemyDinosaur.transform.position.x, EnemyDinosaur.transform.position.y + 5.9f, EnemyDinosaur.transform.position.z), Quaternion.identity);
        smoke.SetActive(true);
        Destroy(EnemyDinosaur);
        //rb.isKinematic=true;
        //rb.useGravity=false;
    }
    // Start is called before the first frame update
    void Start()
    {
    EnemyDinosaur = GameObject.FindGameObjectWithTag("Enemy");
    rb=EnemyDinosaur.GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
