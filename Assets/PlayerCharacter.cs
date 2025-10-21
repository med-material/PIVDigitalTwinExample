using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    private CharacterController controller;
    private Rigidbody rigidbody;
    private bool groundedPlayer;
    private Vector3 playerVelocity;

    [SerializeField]
    private float playerSpeed = 2.0f;

    private float gravityValue = -9.81f;
    
    [SerializeField]
    float timeChange = 10f;


  private void Awake()
    {
        // always add a controller
        controller = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
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

    void FixedUpdate()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        // Get the name of the collided GameObject
        string collidedObjectName = other.gameObject.name;
        
        // Output the name to the console
        Debug.Log("Collided with: " + collidedObjectName);

        if (collidedObjectName == "HolyText") {
         Destroy(other.gameObject);
        }
        if (collidedObjectName == "Wasp") {
        Debug.Log("Add force " + collidedObjectName);
         other.transform.GetComponent<Rigidbody>().AddForce(transform.forward * 2f);
        }
    }

}
