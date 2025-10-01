using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 45;
    
    Vector3 currentEulerAngles;
    float x;
    float y;
    float z;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) x = 1 - x;
        y = 1 - y;
        if (Input.GetKeyDown(KeyCode.Z)) z = 1 - z;

        //modifying the Vector3, based on input multiplied by speed and time
        currentEulerAngles += new Vector3(x, y, z) * Time.deltaTime * rotationSpeed;

        //apply the change to the gameObject
        transform.localEulerAngles = currentEulerAngles;
    }
}
