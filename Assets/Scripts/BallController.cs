using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameManager scoreManager;
    public float speed = 30f;

    public Vector3 Direction { get; private set; }

    private Vector3 initialPosition;

    public void ResetPosition()
    {
        transform.position = initialPosition;
    }

    private void Start()
    {
        // Stores initial position to reset ball when goal is hit.
        initialPosition = transform.position;

        // Determines a random direction to start ball movement:
        // - Randomize x axis to launch the ball to one side.
        // - Randomize z axis in a controlled way to give some noise to direction.
        Direction = new Vector3(Random.value > 0.5f ? 1 : -1, 0, Random.Range(-0.35f, 0.35f));
    }

    private void FixedUpdate()
    {
        transform.position += speed * Time.fixedDeltaTime * Direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var normal = collision.GetContact(0).normal;
        var reflectDirection = Vector3.Reflect(Direction, normal);

        // Randomize the z axis to give some variance.
        reflectDirection.z += reflectDirection.z < 0 ? Random.Range(-0.025f, 0f) : Random.Range(0f, 0.025f);

        Direction = reflectDirection;

        // Checks if ball is colliding with a goal to reset the initial position
        // and keep reflected direction so ball goes scorer side.
        if (collision.collider.CompareTag("AiGoal"))
        {
            scoreManager.OnPlayerScore();
            transform.position = initialPosition;
        }
        else if (collision.collider.CompareTag("PlayerGoal"))
        {
            scoreManager.OnAiScore();
            transform.position = initialPosition;
        }
    }
}