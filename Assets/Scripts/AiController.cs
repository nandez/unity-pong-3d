using UnityEngine;

public class AiController : MonoBehaviour
{
    public BallController ball;

    public float speed = 20f;
    public float lerpSpeed = 5f;

    private Rigidbody rb;
    private Vector3 initialPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    private void FixedUpdate()
    {
        // By default, moves AI pad towards initial position.
        var movement = initialPosition;

        // But if the ball is coming to the AI side, we start following the ball direction.
        if (ball.Direction.x < 0)
        {
            // Determines the if the paddle should be moved up / down (z axis) based on ball position.
            if (ball.transform.position.z > transform.position.z)
                movement = Vector3.forward;
            else if (ball.transform.position.z < transform.position.z)
                movement = Vector3.back;
            else
                movement = Vector3.zero;
        }


        rb.velocity = Vector3.Lerp(rb.velocity, movement * speed, lerpSpeed * Time.fixedDeltaTime);
    }
}