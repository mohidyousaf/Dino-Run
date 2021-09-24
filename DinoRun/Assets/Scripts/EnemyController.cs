using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyPerfect;
public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject Dino;
    public GameObject SmokePrefab;
    [SerializeField] Vector3 ForcetoApply;
    [SerializeField] float Speed;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<Rigidbody>().AddForce(ForcetoApply*Speed);

        if (Dino == null)
        {
            Dino = GameObject.FindGameObjectWithTag("Dino");
        }
    }
    IEnumerator Delay()
    {
        Debug.Log("Delay()");
        yield return new WaitForSeconds(0.7f);

    }
    private void OnTriggerEnter(Collider target)
    {
        //Debug.Log("Dino Entered");

        /*if (target.gameObject.CompareTag("Dino"))
        {
            Debug.Log("Dino Entered");
            //Dino.AddComponent<Rigidbody>();
            //gameObject.GetComponent<Rigidbody>().AddForce(ForcetoApply);
            StartCoroutine(Delay());
            transform.LookAt(Dino.transform);
            if (Dino.GetComponent<PlayerAnimationControl>().getEvolveCount() >= 2)
            {
                //Dino.GetComponent<Rigidbody>().AddForce(ForcetoApply*Speed);
                //gameObject.GetComponent<Rigidbody>().AddForce(ForcetoApply*Speed);
                Debug.Log("I Should be Destroyed");
                GameObject smoke = (GameObject)Instantiate(SmokePrefab, new Vector3(Dino.transform.position.x, Dino.transform.position.y, Dino.transform.position.z), Quaternion.identity);
                smoke.SetActive(true);
                smoke = (GameObject)Instantiate(SmokePrefab, new Vector3(Dino.transform.position.x, Dino.transform.position.y + 2.5f, Dino.transform.position.z), Quaternion.identity);
                smoke.SetActive(true);
                smoke = (GameObject)Instantiate(SmokePrefab, new Vector3(Dino.transform.position.x, Dino.transform.position.y + 5.9f, Dino.transform.position.z), Quaternion.identity);
                smoke.SetActive(true);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("I should nont be destroyed");
            }
            //Destroy(target.gameObject);
        }*/
    }
    private void OnCollisionEnter(Collision target)
    {
    if (target.gameObject.CompareTag("Dino"))
        {
            Debug.Log("Dino Entered");
            //Dino.AddComponent<Rigidbody>();
            //gameObject.GetComponent<Rigidbody>().AddForce(ForcetoApply);
            StartCoroutine(Delay());
            transform.LookAt(Dino.transform);
            if (Dino.GetComponent<PlayerAnimationControl>().getEvolveCount() >= 2)
            {
                //Dino.GetComponent<Rigidbody>().AddForce(ForcetoApply*Speed);
                //gameObject.GetComponent<Rigidbody>().AddForce(ForcetoApply*Speed);
                Debug.Log("I Should be Destroyed");
                GameObject smoke = (GameObject)Instantiate(SmokePrefab, new Vector3(Dino.transform.position.x, Dino.transform.position.y, Dino.transform.position.z), Quaternion.identity);
                smoke.SetActive(true);
                smoke = (GameObject)Instantiate(SmokePrefab, new Vector3(Dino.transform.position.x, Dino.transform.position.y + 2.5f, Dino.transform.position.z), Quaternion.identity);
                smoke.SetActive(true);
                smoke = (GameObject)Instantiate(SmokePrefab, new Vector3(Dino.transform.position.x, Dino.transform.position.y + 5.9f, Dino.transform.position.z), Quaternion.identity);
                smoke.SetActive(true);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("I should nont be destroyed");
            }
            //Destroy(target.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
    Debug.Log("hai");
        if(Dino==null)
            Dino = GameObject.FindGameObjectWithTag("Dino");
        if(transform.position.y<=0.0f)
        {
            Debug.Log("Hi target");
            GetComponent<Rigidbody>().isKinematic=true;
            GetComponent<Rigidbody>().useGravity=false;
        }
        else
        Debug.Log("nuveda");
    }
}
