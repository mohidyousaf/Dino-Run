using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public Vector2 startTouch, deltaTouch;
    public bool isDragging, isRight, isLeft, isMiddle, movingVertical, movingHorizontal;
    public float deltaTouchMargin = 35; //the delta touch magnitude at which player moves

    public Transform player;
    

    public void Start()
    {
        changeDino();
        
        isMiddle = true;
        isRight = isLeft = false;
        
        isDragging = false;
        startTouch = deltaTouch = Vector2.zero;

        movingVertical = true;
        
    }

    //function to find the current dinosaur
    void changeDino()
    {
        player = GameObject.FindWithTag("Dino").transform;
    }

   
    public void Update()
    {
        //updating dinosaur if dinosaur changed
        if (!player){
            changeDino();
        }
        
        //Mouse Input
        if (!isDragging && Input.GetMouseButton(0))
        {
            startTouch = Input.mousePosition;
            isDragging= true;
        }

        else if (isDragging && Input.GetMouseButtonUp(0))
        {
            isDragging= false;
            
            deltaTouch = (Vector2)Input.mousePosition - startTouch;
            
            if(deltaTouch.magnitude > deltaTouchMargin)
            {

                float x = deltaTouch.x;
                Vector3 temp = transform.right * 3;
            
                if(x<0 && !isLeft)
                {
                    player.position -= temp;
                    
                    if (isMiddle){
                        isMiddle = false;
                        isLeft = true;
                    }
                    else if (isRight){
                        isRight = false;
                        isMiddle = true;
                    }
                }

                else if (x>0 && !isRight)
                {
                    player.position += temp;
                   
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
            
            
            // player.position = Vector3.MoveTowards(player.position,newPos,Time.deltaTime * 10);
            
            reset();
        }
 
    //Mobile Input
    /*
        if (Input.touches.Length > 0){  
            if(Input.touches[0].phase == TouchPhase.Began){
                startTouch = Input.touches[0].position;
                //isDragging= true;
            }

            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled){
                //isDragging= false;
                reset();
            }
        }
*/
    //Direction
    /*
        deltaTouch = Vector2.zero;
        if (!isDragging){
        //if (isDragging != 'b'){    
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

    public void reset()
    {
        startTouch = deltaTouch = Vector2.zero;
        isDragging= false;
    }

    public void changeDir()
    {
        if (movingVertical)
        {
            movingVertical = false;
        }
        else
        {
            movingVertical = true;
        }

    }

}

