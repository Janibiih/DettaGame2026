using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem; 

public class NewMonoBehaviourScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Vector2 moveInput; 

    private Object items; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }


}
