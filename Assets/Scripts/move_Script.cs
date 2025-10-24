using UnityEngine;
using UnityEngine.InputSystem;

public class move_Script : MonoBehaviour
{
    float moveForce;
    float jumpForce;

    Vector3 input;

    Rigidbody rb;
    PlayerInput playerInput;
    void Start()
    {
        moveForce= 15f;
        jumpForce =10f;
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }
    public void Jump(InputAction.CallbackContext callbackContex)
    { 
        if (callbackContex.performed) 
        {
            rb.AddForce(Vector3.up * jumpForce);
            Debug.Log("Saltando");
            Debug.Log(callbackContex.phase);
        }
    }
    void Update()
    {
        input = playerInput.actions["Move"].ReadValue<Vector2>();   
    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(input.x, 0f, input.y) * moveForce);
    }
}
