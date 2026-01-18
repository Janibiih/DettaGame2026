using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using Unity.Cinemachine;


public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Vector2 moveInput;
    public int itemCount;

    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] Transform spriteTransform;


    [SerializeField] private CinemachineCamera vCam;
    [SerializeField] private float targetZoomSize;
    public float zoomSpeed = 2f;
    public bool shouldZoom = false;
    public bool zoomed; 
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        itemCount = 0;
        zoomed = false; 
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

        if (shouldZoom)
        {
            vCam.Lens.OrthographicSize = Mathf.Lerp(
                vCam.Lens.OrthographicSize,
                targetZoomSize,
                Time.deltaTime * zoomSpeed
            );

            if (Mathf.Abs(vCam.Lens.OrthographicSize - targetZoomSize) < 0.05f)
            {
                vCam.Lens.OrthographicSize = targetZoomSize;
                shouldZoom = false;
            }
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
        }

        if (collision.gameObject.tag == "Zoom" && zoomed == false)
        {
            targetZoomSize = 5f; 
            shouldZoom = true; 
        }

        if (collision.gameObject.tag == "Zoom2")
        {
            targetZoomSize = 8f;
            shouldZoom = true;
            zoomed = true; 

        }
    }

    

}
