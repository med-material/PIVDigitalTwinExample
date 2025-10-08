using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    private CharacterController controller;
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
        transform.Rotate(Vector3.up, mouseX);

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // gather lateral input control
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 move = transform.TransformDirection(moveInput);

        // scale by speed
        move *= playerSpeed;

        // call .Move() once only
        controller.Move(move * Time.deltaTime);

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision started.");
    }

}
