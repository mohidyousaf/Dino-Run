using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PolyPerfect
{
    public class PlayerAnimationControl : MonoBehaviour
    {
        //public GameObject Trex;
        public GameObject SmokePrefab;
        public Animator anim;
        // Start is called before the first frame update
        public bool GameEnded = false;
        public bool Eating = false;
        public bool attack = false;
        bool flag = false;
        bool NextState = false;
        private int evolveCount=0;
        private int eggCount=0;
        public egg eggCollided;
        public bool instantiated;
        public float lastInstPosX = 0;
        public float lastInstPosZ = 0;
        public bool isFly;
        public int countMistakeOfPlayerForHurdle=0;
        public GameObject bloodPrefab;
        bool uDied=false;
        public void StopPlayer()
        {
            GameEnded = true;
            anim.SetBool("isRunning", false);
            anim.SetBool("isAttacking",false);
            Debug.Log("Inside StopPlayer");
        }
        void OnTriggerEnter(Collider target)
        {
            
            if (target.gameObject.CompareTag("terrain"))
            {
                Debug.Log("terrain collision");
            }
            if (target.gameObject.CompareTag("Egg"))
            {
                Destroy(target.gameObject);

                NextState = true;
                eggCollided  = target.gameObject.GetComponent<egg>();
                
            }
            if(target.gameObject.CompareTag("Hurdle"))
            {
                 if(gameObject.name=="Brachiosaurus Variant")
                 {
                    Debug.Log("I am a hurdle plz destroy me");
                    Destroy(target.gameObject);
                 }
                 else
                 {
                      countMistakeOfPlayerForHurdle++;
                      if(countMistakeOfPlayerForHurdle==2)
                      {
                            /*GameObject smoke = (GameObject)Instantiate(bloodPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z),transform.rotation);           
                            smoke.SetActive(true);*/
                            uDied=true;
                            Debug.Log("player is Dead ");
                            anim.SetBool("isDead",true);
                            StartCoroutine(delayfordeath());
                      }
                 }
            }

        }
        IEnumerator delayfordeath()
        {
            yield return new WaitForSeconds(1.0f);
            if(gameObject.name=="Pachycephalosaurus(Clone)")
            {
                GameObject smoke = (GameObject)Instantiate(bloodPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z),transform.rotation);           
                smoke.SetActive(true);
                smoke = (GameObject)Instantiate(bloodPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+2.5f, gameObject.transform.position.z), transform.rotation);
                smoke.SetActive(true);
                smoke = (GameObject)Instantiate(bloodPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+5.9f, gameObject.transform.position.z),transform.rotation);
                smoke.SetActive(true);
            }
            Destroy(gameObject);
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
        instantiated = false;
        }

        void makeNewDino()
        {
            Vector3 tP;
            if (eggCollided.Flying){
                tP = transform.position + 5*transform.up;
                Debug.Log("isFly is"+ isFly);
                isFly= true;
                Debug.Log("isFly is"+ isFly);
            }
        
            else{
                tP = new Vector3 (transform.position.x,0,transform.position.z);
            }
              
            GameObject myDino = (GameObject)Instantiate(eggCollided.nextDino, tP,transform.rotation);
            GameObject smoke = (GameObject)Instantiate(SmokePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z),transform.rotation);
                    
            smoke.SetActive(true);
            // smoke = (GameObject)Instantiate(SmokePrefab, new Vector3(transform.position.x, transform.position.y+2.5f, transform.position.z), transform.rotation);
            // smoke.SetActive(true);
            // smoke = (GameObject)Instantiate(SmokePrefab, new Vector3(transform.position.x, transform.position.y+5.9f, transform.position.z), Quaternion.identity);
            // smoke.SetActive(true);

                 
            
            Destroy(gameObject);
            myDino.SetActive(true);

            




        }
        // Update is called once per frame
        void Update()
        {
            anim = GetComponent<Animator>();
            //Debug.Log("evolve count is"+ evolveCount);
            if (NextState)
            {
                float currPosX = Mathf.Round(transform.position.x);
                float currPosZ = Mathf.Round(transform.position.z);
                if (!instantiated && currPosX != lastInstPosX && currPosZ != lastInstPosZ){
                    
                    instantiated = true;
                    lastInstPosX = currPosX;
                    lastInstPosZ = currPosZ;
                    
                    makeNewDino();



                }
            }

            if (!GameEnded && !uDied)
            {
                anim.SetBool("isAttacking", false);
                anim.SetBool("isRunning", true);
                //soundPlayer.AnimalSound();
                
                transform.Translate(Vector3.forward * 50 * Time.deltaTime);
                //Rigidbody m_Rigidbody = GetComponent<Rigidbody>();
                //m_Rigidbody.MovePosition(transform.position + Vector3.forward * Time.deltaTime * speed);
                //m_Rigidbody.AddForce(transform.position + Vector3.forward, ) 
            }
            else if (GameEnded )
            {

                // Debug.Log("Entered if statement");
                anim.SetBool("isRunning", false);

                anim.SetBool("isAttacking", true);
                waitingOF(0.10f);
                //anim.SetBool("isAttacking", false);
            }
            else if(uDied)
            {
                anim.SetBool("isRunning", false);
                Debug.Log("hi dead person");
                anim.SetBool("isDead",true);
            }
        }
        IEnumerator waitingOF(float seconds)
        {
            // Debug.Log("waiting()");
            yield return (new WaitForSeconds(seconds));
        }

        public void StartAttacking()
        {
            anim.SetBool("isAttacking",true);
        }
        public void EndGame()
        {
            GameEnded=true;
        }
    }
}