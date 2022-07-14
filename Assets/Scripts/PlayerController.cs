using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;

    private Rigidbody rb;
    private Vector3 initialPosition;

    public void ResetPosition()
    {
        transform.position = initialPosition;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(0, 0, -speed);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}