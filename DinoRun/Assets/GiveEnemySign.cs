using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyPerfect;
public class GiveEnemySign : MonoBehaviour
{
[SerializeField] GameObject EnemyDinosaur;
[SerializeField] GameObject PlayerDinosaur;
[SerializeField] Animator PlayerAnim;
[SerializeField] Animator EnemyAnim;
//[SerializeField] GameObject landingPlaceOfEnemy;
[SerializeField] Vector3 ForceDirection;
[SerializeField] int magnitude;
[SerializeField] float Speed=20f;
[SerializeField] GameObject bloodPrefab;
public bool flag=false;
//public bool uDied=false;
    // Start is called before the first frame update
    void Start()
    {
        EnemyDinosaur=GameObject.FindGameObjectWithTag("Enemy");
        PlayerDinosaur=GameObject.FindGameObjectWithTag("Dino");
        PlayerAnim=PlayerDinosaur.GetComponent<Animator>();
        EnemyAnim=EnemyDinosaur.GetComponent<Animator>();
        //landingPlaceOfEnemy=GameObject.Find("landing Of Enemy");
        //landingPlaceOfEnemy.SetActive(false);
    }
    IEnumerator DestroyEnemy()
    {
        yield return (new WaitForSeconds(1.2f));
        GameObject smoke = (GameObject)Instantiate(bloodPrefab, new Vector3(EnemyDinosaur.transform.position.x, EnemyDinosaur.transform.position.y, EnemyDinosaur.transform.position.z),transform.rotation);           
        smoke.SetActive(true);
        smoke = (GameObject)Instantiate(bloodPrefab, new Vector3(EnemyDinosaur.transform.position.x, EnemyDinosaur.transform.position.y+2.5f, EnemyDinosaur.transform.position.z), transform.rotation);
        smoke.SetActive(true);
        smoke = (GameObject)Instantiate(bloodPrefab, new Vector3(EnemyDinosaur.transform.position.x, EnemyDinosaur.transform.position.y+5.9f, EnemyDinosaur.transform.position.z),transform.rotation);
        smoke.SetActive(true);
        Debug.Log("should get Destroyed");
        Destroy(EnemyDinosaur);
        //uDied=true;
        
    }
    private void OnTriggerEnter(Collider target)
    {
        if(target.gameObject.CompareTag("Dino"))
        {
            PlayerDinosaur.GetComponent<PlayerAnimationControl>().StopPlayer();
            PlayerDinosaur.GetComponent<PlayerAnimationControl>().GameEnded=true;
            PlayerDinosaur.GetComponent<PlayerAnimationControl>().EndGame();
            StartRunningEnemy();
            flag=true;
            Debug.Log("Why trigger not working");
        }
        else if (target.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Inside the collider for Dino Trap");
            StopEnemy();
            PlayerDinosaur.GetComponent<PlayerAnimationControl>().StartAttacking();
            Debug.Log("I should attack");
            //EnemyDinosaur.GetComponent<Rigidbody>().AddForce(ForceDirection * magnitude,ForceMode.Impulse);
            EnemyDinosaur.GetComponent<Rigidbody>().isKinematic=false;
            EnemyDinosaur.GetComponent<Rigidbody>().useGravity=true;
            EnemyDinosaur.GetComponent<Rigidbody>().AddForce(ForceDirection * magnitude,ForceMode.Impulse);
            //landingPlaceOfEnemy.SetActive(true);
            StartCoroutine(DestroyEnemy());
            //uDied=true;
        }
        else
        Debug.Log("Try me");
    }
    private void StartRunningEnemy()
    {
        EnemyAnim.SetBool("isRunning",true);
        // EnemyDinosaur.transform.Translate(Vector3.forward*10* Time.deltaTime);
        Debug.Log("StartRunning");
    }
    private void StopEnemy()
    {
        EnemyAnim.SetBool("isRunning", false);
        flag = false;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerDinosaur = GameObject.FindGameObjectWithTag("Dino");
        PlayerAnim=PlayerDinosaur.GetComponent<Animator>();
        if(flag)
        {
            EnemyDinosaur.transform.position = Vector3.MoveTowards(EnemyDinosaur.transform.position,new Vector3(EnemyDinosaur.transform.position.x -30, EnemyDinosaur.transform.position.y,EnemyDinosaur.transform.position.z),Speed * Time.deltaTime);
            // EnemyDinosaur.transform.Translate(transform.forward * Speed * Time.deltaTime);
            //Debug.Log(EnemyDinosaur.transform.position);
        }
        /*if(uDied)
        {
           GameObject smoke = (GameObject)Instantiate(bloodPrefab, new Vector3(EnemyDinosaur.transform.position.x, EnemyDinosaur.transform.position.y, EnemyDinosaur.transform.position.z),Quaternion.identity);           
        smoke.SetActive(true);
        smoke = (GameObject)Instantiate(bloodPrefab, new Vector3(EnemyDinosaur.transform.position.x, EnemyDinosaur.transform.position.y+2.5f, EnemyDinosaur.transform.position.z), Quaternion.identity);
        smoke.SetActive(true);
        smoke = (GameObject)Instantiate(bloodPrefab, new Vector3(EnemyDinosaur.transform.position.x, EnemyDinosaur.transform.position.y+5.9f, EnemyDinosaur.transform.position.z), Quaternion.identity);
        smoke.SetActive(true);
        Debug.Log("should get Destroyed");
        Destroy(EnemyDinosaur);
        }*/
    }
}
