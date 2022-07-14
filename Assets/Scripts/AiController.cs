using UnityEngine;

public class AiController : MonoBehaviour
{
    public BallController ball;

    public float speed = 20f;
    public float lerpSpeed = 5f;
    public float zMaxOffset = 1.75f;

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

    private void FixedUpdate()
    {
        var movement = Vector3.zero;

        // Checks if the ball is coming to ai side in order to start chasing the ball..
        if (ball.Direction.x < 0)
        {
            // Generates a random offset value representing the distance between the middle of the paddle to edge.
            // This value will be used to move the paddle with a random behavior avoiding always hitting the ball
            // with the center.
            var offset = Random.Range(0, zMaxOffset);

            // Compares positions against z axis to determine the direction to move the paddle.
            if (ball.transform.position.z > transform.position.z + offset)
                movement = Vector3.forward;
            else if (ball.transform.position.z < transform.position.z - offset)
                movement = Vector3.back;
        }
        else
        {
            // In this case, we move the paddle towards initial position..
            if (initialPosition.z > transform.position.z)
                movement = Vector3.forward;
            else if (initialPosition.z < transform.position.z)
                movement = Vector3.back;
        }

        rb.velocity = Vector3.Lerp(rb.velocity, movement * speed, lerpSpeed * Time.fixedDeltaTime);
    }
}