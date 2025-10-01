using UnityEngine;

public class Seagull : MonoBehaviour
{

    [SerializeField]
    GameObject wingR;

    [SerializeField]
    GameObject wingL;

    [SerializeField]
    GameObject birdFlyingCenter;

    [SerializeField]
    float rotationSpeed = 6;

    [SerializeField]
    float flyRadius = 1;
    
    Vector3 wingLcurrentEulerAngles;
    Vector3 wingRcurrentEulerAngles;
    float x;

    float y;

    // Update is called once per frame
    void Update()
    {
        WingsMove();
        FlyAround();
    }

    void FlyAround() {
        y = -1 - y;
        this.transform.localPosition = new Vector3(flyRadius, transform.localPosition.y,transform.localPosition.z);
        birdFlyingCenter.transform.localEulerAngles += new Vector3(0, y, 0) * Time.deltaTime * rotationSpeed;
    }


    void WingsMove() {
        x = 1 - x;
        //modifying the Vector3, based on input multiplied by speed and time
        wingLcurrentEulerAngles = wingL.transform.localEulerAngles;
        wingLcurrentEulerAngles += new Vector3(x, 0, 0) * Mathf.Sin(Time.time * rotationSpeed);

        wingRcurrentEulerAngles = wingR.transform.localEulerAngles;
        wingRcurrentEulerAngles += new Vector3(x, 0, 0) * Mathf.Sin(Time.time * rotationSpeed);


        //apply the change to the gameObject
        wingL.transform.localEulerAngles = wingLcurrentEulerAngles;
        wingR.transform.localEulerAngles = wingRcurrentEulerAngles;
    }

}
