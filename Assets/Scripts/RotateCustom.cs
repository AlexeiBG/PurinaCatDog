using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotateCustom : MonoBehaviour {
 
    //rotation speed
    public float rotSpeed = 200;

    //touch speed
    public float speed = .1f;
    //time to rotate
    public float timeLeft = 5f;
    //time after it gets dragged around
    public float timeRot = 10f;

    private Quaternion originalRotation;
 

    //saves the original rotation of the obj
    void Start(){
        originalRotation = transform.rotation;
        
    }

    //if its not moving around, the timer will reset to the original position
	private void Update()
	{
       

        //moving cube only/*
        /*
        if (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
           
            Vector2 touchDeltaPos = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPos.x * speed, -touchDeltaPos.y * speed, 0);
            Debug.Log("moving camera stuff "+touchDeltaPos);
        }
        */

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //move only horizontally

            //reset timer
            newTimer();
            Vector2 touchDeltaPos = Input.GetTouch(0).deltaPosition;
            float rotX = touchDeltaPos.x * rotSpeed * Mathf.Deg2Rad;
            transform.Rotate(Vector3.up, -rotX);

            //move only vertically
            // float rotY = touchDeltaPos.y * rotSpeed * Mathf.Deg2Rad;
            // transform.Rotate(Vector3.right, rotY);
        }
    }
    //Only to count
    private void LateUpdate()
    {
        //simple countdown to reset, unless its dragged again
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Camera.main.fieldOfView -= 60.0f * .05f;
            resetPos();
        }
        // it might avoid NaN
        if (timeLeft < -100)
        {
            timeLeft = -10;
        }
    }

    //each time it moves the timer gets a new value, only works with mouse
    /*
	private void OnMouseDrag()
	{
        timeLeft = timeRot;
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
      // float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
       transform.Rotate(Vector3.up, -rotX);
        //transform.Rotate(Vector3.right, rotY);
       
	}
    */

    


    //function to put a new timer each movement on model
    public void newTimer()
    {
        timeLeft = timeRot;
    }


    //reset to desired position with a smooth transition
    private void resetPos(){
        
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, originalRotation, Time.deltaTime);
    }

    private void calculateAngle(){
        float angle = Quaternion.Angle(transform.rotation, transform.parent.rotation);
        Debug.Log("quat angle: " + angle);
    }

}
