using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem; 

public class NewMonoBehaviourScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Vector2 moveInput;
    public int itemCount;

    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] Transform spriteTransform; 


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        itemCount = 0; 
    }

    private void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;

        float targetAngle = 0f; 

        if (moveInput != Vector2.zero)
        {
            targetAngle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg - 90f;
            Quaternion targetRot = Quaternion.Euler(0, 0, targetAngle);
            spriteTransform.rotation = Quaternion.Lerp(spriteTransform.rotation, targetRot, rotateSpeed * Time.deltaTime);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            Destroy(collision.gameObject); 
            itemCount ++;
            Debug.Log("Items: " + itemCount);
        }
    }


}
