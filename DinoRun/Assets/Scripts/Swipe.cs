using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public Vector2 startTouch, deltaTouch;
    public bool isDragging, isRight, isLeft, isMiddle, movingVertical, movingHorizontal;
    public float deltaTouchMargin = 35; //the delta touch magnitude at which player moves
    public float change;
    public Transform player;
    

   public void Start()
    {
        changeDino();
        
        
        if (gameObject.tag == "SwipeController" || gameObject.name == "Brachiosaurus Variant")
        {
            isMiddle = true;
            isRight = isLeft = false;
            isDragging = false;
            startTouch = deltaTouch = Vector2.zero;

            movingVertical = true;
        }
        else
        {
        Swipe swTest = this.GetComponent<Swipe>();

        Swipe swController = GameObject.FindWithTag("SwipeController").GetComponent<Swipe>();

        swTest.isMiddle = swController.isMiddle;
            swTest.isLeft = swController.isLeft;
            swTest.isRight = swController.isRight;
            swTest.movingVertical = swController.movingVertical;
            Debug.Log("new isMiddle:" + swTest.isMiddle);
        }

            
        
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

        if (player.name == "Brachiosaurus Variant" || player.name == "Brachiosaurus Variant(Clone)"){
    
            change = 2.9f;
           
        }
            
        else if (player.name == "Velociraptor(Clone)"){
            change = 5f;
        }
        

        else if (player.name == "Pachycephalosaurus(Clone)"){
            change = 5f;
            
        }

        else if (player.name == "Pteranodon(Clone)"){
           change = 5;
            
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
                Vector3 temp = transform.right * change;
            
                if(x<0 && !isLeft)
                {
                     
                    player.position=  Vector3.Lerp (player.position,player.position-temp, Time.deltaTime * 120);  
                    // player.position -= temp;
                    
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
                    player.position= Vector3.Lerp (player.position,player.position+temp, Time.deltaTime * 120); 
                    // player.position += temp;
                   
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
    
        else if (Input.touches.Length > 0){  
            if(Input.touches[0].phase == TouchPhase.Began){
                startTouch = Input.touches[0].position;
                isDragging= true;
            }
        }
            

        else if ( isDragging && (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)){
            isDragging= false;
            deltaTouch = Input.touches[0].position - startTouch;

            if(deltaTouch.magnitude > deltaTouchMargin)
            {

                float x = deltaTouch.x;
                Vector3 temp = transform.right * 3;
            
                if(x<0 && !isLeft)
                {
                    // player.position= Vector3.MoveTowards(player.position,player.position-temp,5*Time.deltaTime);
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
                    // player.position= Vector3.MoveTowards(player.position,player.position+temp,5*Time.deltaTime);
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
    }

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

