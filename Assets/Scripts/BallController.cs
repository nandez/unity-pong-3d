using UnityEngine;

public class BallController : MonoBehaviour
{
    public ScoreManager scoreManager;
    public float speed = 30f;

    public Vector3 Direction { get; private set; }

    private Vector3 initialPosition;

    private void Start()
    {
        // Stores initial position to reset ball when goal is hit.
        initialPosition = transform.position;

        // Determines a random direction to start ball movement:
        Direction = new Vector3(
            Random.value > 0.5f ? 1 : -1, // Randomize x axis to launch the ball to one side.
            0,
            Random.Range(-0.35f, 0.35f) // Randomize z axis in a controlled way to give some noise to direction.
        );
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * Direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var normal = collision.contacts[0].normal;
        Direction = Vector3.Reflect(Direction, normal);

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