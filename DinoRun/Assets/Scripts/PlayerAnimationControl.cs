using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PolyPerfect
{
    public class PlayerAnimationControl : MonoBehaviour
    {
        public GameObject Trex;
        public GameObject SmokePrefab;
        public Animator anim;
        // Start is called before the first frame update
        public bool GameEnded = false;
        public bool Eating = false;
        public bool attack = false;
        bool flag = false;
        bool NextState = false;
        public int evolveCount=0;
        private int eggCount=0;

        public void StopPlayer()
        {
            GameEnded = true;
            anim.SetBool("isRunning", false);
            anim.SetBool("isAttacking",false);
        }
        void OnTriggerEnter(Collider target)
        {
            if (target.gameObject.CompareTag("Dino")) // if enemy encounters our player enemy should play its animation
            {
                //anim.SetBool("Attack",true);
            }
            if (target.gameObject.CompareTag("terrain"))
            {
                Debug.Log("terrain collision");
            }
            if (target.gameObject.CompareTag("Egg"))
            {
                Destroy(target.gameObject);

                // increasing egg count by 1
                eggCount++;
                // Debug.Log("egg count is " + eggCount);

                //if egg count is multiple of 2 , evolve

                if(eggCount % 2 ==0){
                    // Debug.Log("changing transition as egg count is multiple of 2");
                    NextState = true;
                }
                   
                
            }
            if (target.gameObject.CompareTag("terrain"))
            {
                Debug.Log("here we have a terrain!");
            }
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag("terrain"))
            {
                Debug.Log("collided at the difference");// + transform.position.x-col.gameObject.transform.position.x
            }
            if (col.gameObject.CompareTag("boundary"))
            {
                Debug.Log("collided with boundary");
            }
        }
        //public Common_PlaySound soundPlayer;
        void Start()
        {
          
            // anim = GetComponent<Animator>();
            if (anim != null)
            {
                // Debug.Log("Animator is not null");
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            anim = GetComponent<Animator>();
            //Debug.Log("evolve count is"+ evolveCount);
            if (NextState)
            {

                evolveCount++;
                GameObject myTrex=(GameObject)Instantiate(Trex, transform.position, Quaternion.identity);
                GameObject smoke = (GameObject)Instantiate(SmokePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z),Quaternion.identity);
                smoke.SetActive(true);
                smoke = (GameObject)Instantiate(SmokePrefab, new Vector3(transform.position.x, transform.position.y+2.5f, transform.position.z), Quaternion.identity);
                smoke.SetActive(true);
                smoke = (GameObject)Instantiate(SmokePrefab, new Vector3(transform.position.x, transform.position.y+5.9f, transform.position.z), Quaternion.identity);
                smoke.SetActive(true);
                //gameObject.SetActive(false);
                myTrex.SetActive(true);
                // anim.SetBool("isAttacking", false);
                // anim.SetBool("isRunning", true);
                // myTrex.transform.rotation = gameObject.transform.rotation;
                Destroy(gameObject);
            }

            if (!GameEnded && !Eating)
            {
                anim.SetBool("isAttacking", false);
                anim.SetBool("isRunning", true);
                //soundPlayer.AnimalSound();
                
                transform.Translate(Vector3.forward * 10 * Time.deltaTime);
                //Rigidbody m_Rigidbody = GetComponent<Rigidbody>();
                //m_Rigidbody.MovePosition(transform.position + Vector3.forward * Time.deltaTime * speed);
                //m_Rigidbody.AddForce(transform.position + Vector3.forward, )
            }
            else if (GameEnded)
            {

                // Debug.Log("Entered if statement");
                anim.SetBool("isRunning", false);

                //anim.SetBool("isAttacking", true);
                waitingOF(0.10f);
                //anim.SetBool("isAttacking", false);
            }
        }
        public void StartAttacking()
        {
            anim.SetBool("isAttacking",true);
        }
        public int getEvolveCount()
        {
            return evolveCount;
        }
       
        IEnumerator waitingOF(float seconds)
        {
            // Debug.Log("waiting()");
            yield return (new WaitForSeconds(seconds));
        }

    }
}