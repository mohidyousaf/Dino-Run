using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PolyPerfect
{
    public class PlayerAnimationControl : MonoBehaviour
    {
        public GameObject Trex;
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
        void Update()
        {
            anim = GetComponent<Animator>();
            Debug.Log("i am here");
            if (NextState)
            {
                GameObject myTrex=(GameObject)Instantiate(Trex, transform.position, Quaternion.identity);
                //gameObject.SetActive(false);
                myTrex.SetActive(true);
                // anim.SetBool("isAttacking", false);
                // anim.SetBool("isRunning", true);
                myTrex.transform.rotation = gameObject.transform.rotation;
                Destroy(gameObject);
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