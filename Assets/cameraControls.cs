using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControls : MonoBehaviour
{
    public int cameraDragSpeed = 275;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // moves camera around with Middle Mouse Click
        if (Input.GetMouseButton(2)){
            float speed = cameraDragSpeed * Time.deltaTime;
            Camera.main.transform.position -= new Vector3(Input.GetAxis("Mouse X") * speed, Input.GetAxis("Mouse X") * speed, Input.GetAxis("Mouse Y") * speed);
        }
        // rotates camera with Right Mouse Click
        if (Input.GetMouseButton(1)){
            float speed = cameraDragSpeed * Time.deltaTime;
            
             Camera.main.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * speed, Input.GetAxis("Mouse X") * speed, Input.GetAxis("Mouse X") * speed), Space.World);
        }
    }
}
