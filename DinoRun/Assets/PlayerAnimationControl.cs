using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PolyPerfect
{
    public class PlayerAnimationControl : MonoBehaviour
    {
        public GameObject Trex;
        public GameObject Smoke;
        public Animator anim;
        // Start is called before the first frame update
        public bool GameEnded = false;
        public bool Eating = false;
        public bool attack = false;
        bool flag = false;
        bool NextState = false;
        void OnTriggerEnter(Collider target)
        {
            if (target.gameObject.CompareTag("Egg"))
            {
                NextState = true;
            }
        }
        //public Common_PlaySound soundPlayer;
        void Start()
        {
            anim = GetComponent<Animator>();
            if (anim != null)
            {
                Debug.Log("Animator is not null");
            }
        }

        // Update is called once per frame
        IEnumerator waitsForTime(float seconds)
        {
            Destroy(gameObject);
            Debug.Log("waiting function()");
            GameObject mySmoke = (GameObject)Instantiate(Smoke, transform.position, Quaternion.identity);
            mySmoke.SetActive(true);
             mySmoke = (GameObject)Instantiate(Smoke, transform.position, Quaternion.identity);
             mySmoke.transform.position = new Vector3(mySmoke.transform.position.x, mySmoke.transform.position.y + 2.5f, mySmoke.transform.position.z);

            mySmoke.SetActive(true);
             mySmoke = (GameObject)Instantiate(Smoke, transform.position, Quaternion.identity);
             mySmoke.transform.position= new Vector3(mySmoke.transform.position.x, mySmoke.transform.position.y + 5.9f, mySmoke.transform.position.z);
            mySmoke.SetActive(true);
            mySmoke.transform.rotation = gameObject.transform.rotation;


            GameObject myTrex = (GameObject)Instantiate(Trex, transform.position, Quaternion.identity);
            //gameObject.SetActive(false);
            myTrex.SetActive(true);
            myTrex.transform.rotation = gameObject.transform.rotation;
            
            yield return new WaitForSeconds(seconds);

            //Destroy(mySmoke.gameObject);
            

           
            Debug.Log("Yamaha Motorcycle");
        }
        void Update()
        {
            if (NextState)
            {
                

                
               


                StartCoroutine(waitsForTime(2.5f));
                
                NextState = false;
            }

            if (!GameEnded && !Eating)
            {
                anim.SetBool("isAttacking", false);
                anim.SetBool("isRunning", true);
                //soundPlayer.AnimalSound();
                transform.Translate(Vector3.forward * 5 * Time.deltaTime);
            }
            else if (GameEnded)
            {

                Debug.Log("Entered if statement");
                anim.SetBool("isRunning", false);

                anim.SetBool("isAttacking", true);
                waitingOF(0.10f);
                //anim.SetBool("isAttacking", false);
            }
        }
        IEnumerator waitingOF(float seconds)
        {
            Debug.Log("waiting()");
            yield return (new WaitForSeconds(seconds));
        }
    }
}