using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour
{
    private GameObject player;

   
    //We need a max time and min distance in order to identify a swipe movement
    public float maxTime; // a good value would be 0.5f 
    public float minSwipeDist; //a good value would be 50

    public float startTime;
    public float endTime;


    Vector3 startPos;
    Vector3 endPos;

    float swipeDistance;
    float swipeTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTime = Time.time; //when we first touch the screen we start the time and we store than into the startTime varable
                startPos = touch.position; //we also store the position of our first touch
            }


            else if (touch.phase == TouchPhase.Ended)
            {
                endTime = Time.time; //again we store the current time when we lift our finger
                endPos = touch.position; //and also its position

                swipeDistance = (endPos - startPos).magnitude; //the magnitude gives us the distance between two points
                swipeTime = endTime - startTime; //we store the whole time of the swipe

                if(swipeTime< maxTime && swipeDistance > minSwipeDist)
                {
                    swipe();
                }
            }
         
        }

        void swipe()
        {
            //First of all we try to figure out if the swipe is Vertical or Horizontal
            Vector2 distance = endPos - startPos;

            if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
            {
                Debug.Log("Horizontal swipe");
                if (distance.x > 0)
                {
                    Debug.Log("Right Swipe!");
                }
                if (distance.x < 0)
                {
                    Debug.Log("Right Swipe!");
                }
            }



            else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y)) 
            {
                Debug.Log("Vertical swipe");
                if (distance.y > 0)
                {
                    Debug.Log("Up Swipe!");
                    player.GetComponent<PlayerJump>().jump();
                }
                if (distance.y < 0)
                {
                    Debug.Log("Down Swipe!");
                }
            }
               
            
        }
    } 
}


