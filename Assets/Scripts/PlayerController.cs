using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private CinemachineCamera camera;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5f;

    private Vector3 moveDir = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputManager.OnMove.AddListener(MovePlayer);

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, camera.transform.rotation.eulerAngles.y, 0);
    }

    void MovePlayer(Vector3 direction)
    {
        Vector3 cf = camera.transform.forward;
        Vector3 cr = camera.transform.right;
        cf.y = 0;
        cr.y = 0;
        moveDir = cf * direction.z + cr * direction.x;
        rb.linearVelocity = new Vector3(moveDir.x * speed, rb.linearVelocity.y, moveDir.z * speed);
    }

    //private void FixedUpdate()
    //{
        
    //}


}
