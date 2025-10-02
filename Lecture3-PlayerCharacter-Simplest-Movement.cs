using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    // note: set the skin width properly on the character controller, 0.18 causes teh character controller to "fly around".
    // more advanced example with jumping and gravity:
    // https://docs.unity3d.com/ScriptReference/CharacterController.Move.html

    private CharacterController controller;

    [SerializeField]
    private float playerSpeed = 2.0f;

  private void Awake()
    {
        // always add a controller
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        // gather lateral input control
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // scale by speed
        move *= playerSpeed;

        // call .Move() once only
        controller.Move(move * Time.deltaTime);

    }
}
