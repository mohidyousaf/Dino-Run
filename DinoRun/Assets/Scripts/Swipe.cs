using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{

    public bool swipeLeft, swipeRight;
    public Vector2 startTouch, deltaTouch;
    public bool isDraging, isRight, isLeft, isMiddle;
    //public char isDraging;

    //changes
    public Transform player;

    private float change = 7, xNew;
    
    public Vector3 newPos;


    public void Start(){
        //isDraging = 'a';
        isMiddle = true;
        isDraging = false;
        swipeLeft = swipeRight = false;
        startTouch = deltaTouch = Vector2.zero;
        isRight = isLeft = false;
        //a = start; b= mouse dragging; c = mouse down
    }

    // Update is called once per frame
    public void Update()
    {
        
    //Mouse Input
        if (!isDraging && Input.GetMouseButton(0)){
            startTouch = Input.mousePosition;
            isDraging= true;
            //Debug.Log("tapped");

        }

        else if (isDraging && Input.GetMouseButtonUp(0)){
            isDraging= false;
            deltaTouch = Vector2.zero;
            //isDraging= 'c';
            deltaTouch = (Vector2)Input.mousePosition - startTouch;
            Debug.Log("mouse: "+ Input.mousePosition.x + ", " +  Input.mousePosition.y);
            Debug.Log("starttouch: "+ startTouch[0] + ", " + startTouch[1]);
            Debug.Log("deltatouch: "+ deltaTouch[0] + ", " +  deltaTouch[1]);

            Debug.Log("The magnitude is "+ deltaTouch.magnitude);
            
            if(deltaTouch.magnitude > 35){

                float x = deltaTouch.x;
            
                if(x<0 && !isLeft){
                    //swipeLeft = true;
                    //isLeft = true;
                    xNew = player.position.x - change;
                    if (isMiddle){
                        isMiddle = false;
                        isLeft = true;
                    }
                    else if (isRight){
                        isRight = false;
                        isMiddle = true;
                    }
                }

                else if (x>0 && !isRight){
                    //swipeRight=true;
                    xNew = player.position.x + change;
                    //isRight = true;
                    if (isMiddle){
                        isMiddle = false;
                        isRight = true;
                    }
                    else if (isLeft){
                        isLeft = false;
                        isMiddle = true;
                    }
                }
            }  
            newPos = new Vector3(xNew, player.position.y, player.position.z);
            player.position = newPos;
            //Debug.Log("The magnitude is "+ deltaTouch.magnitude);
            reset();
            //startTouch = deltaTouch = Vector2.zero;
        }
 
    //Mobile Input
    /*
        if (Input.touches.Length > 0){  
            if(Input.touches[0].phase == TouchPhase.Began){
                startTouch = Input.touches[0].position;
                //isDraging= true;
            }

            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled){
                //isDraging= false;
                reset();
            }
        }
*/
    //Direction
    /*
        deltaTouch = Vector2.zero;
        if (!isDraging){
        //if (isDraging != 'b'){    
            // Debug.Log("Still dragging");
            //Debug.Log("Input.touches.Length: " + Input.touches.Length);
            //Debug.Log("Input touches"+ Input.touches);
            if (Input.touches.Length>0){
                deltaTouch = Input.touches[0].position - startTouch;
            }

            //else if (Input.GetMouseButtonUp(0)){
            else{
                deltaTouch = (Vector2)Input.mousePosition - startTouch;
                Debug.Log(deltaTouch.GetType());
                Debug.Log("mouse: "+ Input.mousePosition.x + Input.mousePosition.y);
                Debug.Log("starttouch: "+ startTouch[0] + startTouch[1]);
                Debug.Log("deltatouch: "+ deltaTouch[0] + deltaTouch[1]);
                //Debug.Log("The magnitude is "+ deltaTouch.magnitude);
            }

            
        }
*/

    //magnitude check

        
    }

    public void reset(){
        startTouch = deltaTouch = Vector2.zero;
        isDraging= false;
        //swipeLeft = swipeRight = false;
        //isDraging= 'c';

    }





}

