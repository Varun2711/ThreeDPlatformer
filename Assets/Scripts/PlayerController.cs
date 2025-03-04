using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private CinemachineCamera camera;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 1.5f;

    private float jumpCount = 0;

    private Vector3 moveDir = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnJump.AddListener(Jump);

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, camera.transform.rotation.eulerAngles.y, 0);
    }

    void MovePlayer(Vector3 direction)
    {
        float speed = moveSpeed;
        if (jumpCount > 0)
        {
            speed /= 2.2f;
        }
        Vector3 cf = camera.transform.forward;
        Vector3 cr = camera.transform.right;
        cf.y = 0;
        cr.y = 0;
        moveDir = cf * direction.z + cr * direction.x;
        rb.linearVelocity = new Vector3(moveDir.x * speed, rb.linearVelocity.y, moveDir.z * speed);
    }

    void Jump()
    {
        if (jumpCount < 2)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            jumpCount = 0;
        }
    }


}
