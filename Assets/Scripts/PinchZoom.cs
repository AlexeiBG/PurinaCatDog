using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PinchZoom : MonoBehaviour {

    Camera camera;
    public float persZoomSpeed = .05f;
    public float ortoZoomSpeed = .5f;
    public float maxOrtoSize = .1f;
    public float maxPersAngle = 100.0f;

    private Touch touchZero;
    private Touch touchOne;

    [SerializeField]
    private RotateCustom rC;
    
    private void Reset()
    {
        PinchZoom pz = GetComponent<PinchZoom>();
    }

    private void Start()
    {
        rC = FindObjectOfType<RotateCustom>();
        camera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        Debug.Log("how many finger are on screen "+Input.touchCount);
        if (Input.touchCount==2 )
        {
            //get two touches in variables, force them to pressure 1
            if (Input.GetTouch(0).pressure == 1 && Input.GetTouch(1).pressure == 1)
            {
                touchZero = Input.GetTouch(0);
                touchOne = Input.GetTouch(1);

                if (touchZero.phase == TouchPhase.Moved && touchOne.phase == TouchPhase.Moved &&
                   touchZero.pressure == 1f && touchOne.pressure == 1f)
                {
                    Debug.Log("finger 1  pressure " + touchZero.pressure);
                    Debug.Log("finger 2 pressure " + touchOne.pressure);

                    rC.newTimer();

                    //detect where the touches began
                    Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                    Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                    //
                    float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                    float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                    //finger move apart if negative
                    float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
                    //if camera is orto or perspective
                    if (camera.orthographic)
                    {
                        camera.orthographicSize += deltaMagnitudeDiff - ortoZoomSpeed;
                        camera.orthographicSize = Mathf.Max(camera.orthographicSize, maxOrtoSize);
                    }
                    else
                    {
                        camera.fieldOfView += deltaMagnitudeDiff * persZoomSpeed;
                        camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, .1f, maxPersAngle);
                    }
                }
                else if (touchOne.phase == TouchPhase.Ended && touchZero.phase == TouchPhase.Ended)
                {
                    //reset position after a while, how?
                    Debug.Log("touches stopped");
                }
            }
            
        }
        else if (Input.touchCount > 2)
        {
            Debug.Log("disabling multi touch");
            Input.multiTouchEnabled = false;
            Debug.Log(Input.GetTouch(0).position);
            Debug.Log(Input.GetTouch(1).position);
        }
    }
}
