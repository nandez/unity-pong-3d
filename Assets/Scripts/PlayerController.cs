using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(0, 0, Speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(0, 0, -Speed);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}