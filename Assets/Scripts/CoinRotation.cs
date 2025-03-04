using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    private float rotationSpeed = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + rotationSpeed * Time.deltaTime, 0);
    }
}
