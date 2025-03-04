using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();
    public UnityEvent OnJump = new UnityEvent();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // jump input controls
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump?.Invoke();
        }
        // movement input controls
        Vector3 inputDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            inputDirection += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputDirection += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputDirection += Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputDirection += Vector3.left;
        }

        OnMove?.Invoke(inputDirection);
    }
}
