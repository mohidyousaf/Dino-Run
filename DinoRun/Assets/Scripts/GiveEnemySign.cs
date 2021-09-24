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
    [SerializeField] float Speed=20f;
    [SerializeField] Vector3 ForceDirection;
    [SerializeField] GameObject landingPlaceOfEnemy;
    [SerializeField] int magnitude;
    bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        EnemyDinosaur = GameObject.FindGameObjectWithTag("Enemy");
        PlayerDinosaur = GameObject.FindGameObjectWithTag("Dino");
        landingPlaceOfEnemy=GameObject.Find("Landing Of enemy");
        landingPlaceOfEnemy.SetActive(false);
    }
    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.CompareTag("Dino"))
        {
            PlayerAnim=PlayerDinosaur.GetComponent<Animator>();
            EnemyAnim = EnemyDinosaur.GetComponent<Animator>();
            PlayerDinosaur.GetComponent<PlayerAnimationControl>().StopPlayer();
            StartRunning();
            flag = true;
        }
        if (target.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Inside the collider for Dino Trap");
            StopEnemy();
            //PlayerAnim.SetBool("isAttacking", true);
            PlayerDinosaur.GetComponent<PlayerAnimationControl>().StartAttacking();
            Debug.Log("I should attack");
            //EnemyDinosaur.GetComponent<Rigidbody>().AddForce(ForceDirection * magnitude,ForceMode.Impulse);
            EnemyDinosaur.GetComponent<Rigidbody>().isKinematic=false;
            EnemyDinosaur.GetComponent<Rigidbody>().useGravity=true;
            EnemyDinosaur.GetComponent<Rigidbody>().AddForce(ForceDirection * magnitude,ForceMode.Impulse);
            landingPlaceOfEnemy.SetActive(true);
        }
        if(target.gameObject==landingPlaceOfEnemy)
        {
        Debug.Log("Zindabad");
        }
    }

    private void StopEnemy()
    {
        EnemyAnim.SetBool("isRunning", false);
        flag = false;
    }
    private void StartRunning()
    {
        EnemyAnim.SetBool("isRunning", true);
        Debug.Log("Start running");
        //Debug.Log(EnemyDinosaur.transform.position);
        EnemyDinosaur.transform.Translate(Vector3.forward* 20);
        //Debug.Log(EnemyDinosaur.transform.position);
        Debug.Log("runner");
    }
    // Update is called once per frame
    IEnumerator Delay()
    {
        Debug.Log("Delay()");
        yield return new WaitForSeconds(0.3f);

    }
    void FixedUpdate()
    {
            //EnemyDinosaur.GetComponent<Rigidbody>().AddForce(ForceDirection * magnitude,ForceMode.Impulse);

    }
    void Update()
    {
        PlayerDinosaur = GameObject.FindGameObjectWithTag("Dino");
        if(flag)
        {
        EnemyDinosaur.transform.Translate(transform.forward * Speed * Time.deltaTime);
        Debug.Log(EnemyDinosaur.transform.position);
        }
    }
}
