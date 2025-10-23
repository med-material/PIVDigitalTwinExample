using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{

    [SerializeField]
    Transform target;

    [SerializeField]
    float timeChange = 10f;

    [SerializeField]
    float verMovement = 1f;

    [SerializeField]
    Vector3 offset;

    Quaternion currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        currentRotation = this.transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        float mouseY = Input.GetAxis("Mouse Y") * timeChange;
        float mouseX = Input.GetAxis("Mouse X") * timeChange;
        //transform.Rotate(Vector3.right, mouseY);

        // Create quaternion for the yaw (horizontal rotation)
        Quaternion yawRotation = Quaternion.AngleAxis(mouseX, Vector3.up);
        
        // Create quaternion for the pitch (vertical rotation)
        Quaternion pitchRotation = Quaternion.AngleAxis(-mouseY, Vector3.right);
        
        // Combine rotations
        currentRotation = yawRotation * currentRotation; // Apply yaw first
        currentRotation *= pitchRotation; // Then apply pitch

        // Update the camera's position based on the target and offset
        transform.position = target.transform.position + currentRotation * offset;
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, target.transform.position.y + verMovement * 0.1f,target.transform.position.y +verMovement), transform.position.z);

        // Have the camera look at the target
        transform.LookAt(target.transform.position);

        //Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Slerp(transform.position, desiredPosition, timeChange * Time.deltaTime);
        //transform.position = mouseYRot * transform.position;
        //transform.Rotate(Vector3.right, mouseYRot);
        //transform.position = target.position + offset;

        //transform.LookAt(target);


        //float x = Input.GetAxis("Mouse X");
        //float y = Input.GetAxis("Mouse Y");


        //transform.RotateAround(target.transform.position, transform.up, x * timeChange * Time.deltaTime);


        //transform.RotateAround(target.transform.position, transform.right, -y * timeChange * Time.deltaTime);


        //transform.LookAt(target);

        //Vector3 cameraRotation = transform.eulerAngles;
        //cameraRotation.y = Mathf.Clamp(cameraRotation.y, -90, 90);
        //cameraRotation.z = 0;

        //transform.eulerAngles = cameraRotation;




    }
}
