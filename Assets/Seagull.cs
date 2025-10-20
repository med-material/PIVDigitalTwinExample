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

    GameObject goldenEgg;
    bool moveEgg = false;

    // Update is called once per frame
    void Update()
    {
        WingsMove();
        FlyAround();

        if (moveEgg) {
            EggMovement();
        } else {
            DropGoldenEgg();
        }
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

    void DropGoldenEgg() {
        Vector3 down = transform.TransformDirection(Vector3.up * -10);
        Debug.DrawRay(transform.position, down, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, down, out hit, 10f, Physics.DefaultRaycastLayers)) {
            if (hit.collider) {
                if (hit.collider.gameObject.name == "Player") {
                    goldenEgg = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    goldenEgg.transform.position = this.transform.position;
                    goldenEgg.transform.localScale = new Vector3(0.05f,0.05f,0.05f);
                    moveEgg = true;              
                }
            }
        }
    }

    void EggMovement() {
        goldenEgg.transform.position = new Vector3(goldenEgg.transform.position.x, goldenEgg.transform.position.y - 0.01f, goldenEgg.transform.position.z);
    }

}
