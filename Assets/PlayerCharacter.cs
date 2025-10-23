using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{

    private CharacterController controller;
    private Rigidbody rigidbody;
    private bool groundedPlayer;
    private Vector3 playerVelocity;

    [SerializeField]
    private TMP_Text holyTextCounter;

    [SerializeField]
    private TMP_Text collectedText;

    [SerializeField]
    private Button myButton;

    [SerializeField]
    private float playerSpeed = 2.0f;

    private float gravityValue = -9.81f;

    private int holyTextCount = 0;
    
    [SerializeField]
    float timeChange = 10f;

    private bool canControl = true;


  private void Awake()
    {
        // always add a controller
        controller = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        holyTextCounter.text = holyTextCount.ToString();
    }

    public void IncreaseSpeed() {
        playerSpeed += 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float mouseX = Input.GetAxis("Mouse X") * timeChange;
        transform.Rotate(Vector3.up * mouseX);

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        if (canControl) {
            // gather lateral input control
            Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), playerVelocity.y, Input.GetAxis("Vertical"));
            Vector3 move = transform.TransformDirection(moveInput);

            // scale by speed
            move *= playerSpeed;

            // call .Move() once only
            controller.Move(move * Time.deltaTime);

            Vector3 forward = transform.TransformDirection(Vector3.forward * 10);
            Debug.DrawRay(transform.position, forward, Color.green);
        }
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        Debug.DrawRay(transform.position, Vector3.forward, Color.red);

    }

    void OnTriggerEnter(Collider other)
    {
        // Get the name of the collided GameObject
        string collidedObjectName = other.gameObject.name;
        
        // Output the name to the console
        Debug.Log("Collided with: " + collidedObjectName);

        if (collidedObjectName == "HolyText") {
            Destroy(other.gameObject);
            holyTextCount++;
            holyTextCounter.text = holyTextCount.ToString();
            StartCoroutine(Collected(1.2f));
        }
        if (collidedObjectName == "Wasp") {
            Debug.Log("Add force " + collidedObjectName);
            IEnumerator coroutine = GetStung(1.5f);
            StartCoroutine(coroutine);
            //other.transform.GetComponent<Rigidbody>().AddForce(transform.forward * 2f);
        }
    }

   // every 2 seconds perform the print()
    private IEnumerator Collected(float waitTime)
    {
            collectedText.enabled = true;
            float time = 0f;
            float step = 0.01f;
            float alpha = 0f;
            while (time < waitTime) {
                time += Time.deltaTime * 4;
                alpha = Mathf.Lerp(1f,0f,(time/waitTime));
                Debug.Log(alpha);
                collectedText.color = new Color(255f,255f,255f,alpha);
                yield return null;
            }
            collectedText.enabled = false;
    }

    // every 2 seconds perform the print()
    private IEnumerator GetStung(float waitTime)
    {
            canControl = false;
            controller.enabled = false;
            transform.GetComponent<Rigidbody>().AddForce(transform.up * 54f);
            print("WaitAndPrint " + Time.time);
            yield return new WaitForSeconds(waitTime);
            canControl = true;
            controller.enabled = true;
    }

}
