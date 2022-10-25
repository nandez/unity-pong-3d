using UnityEngine;

public class AiController : MonoBehaviour
{
    [SerializeField] private BallController ball;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float topWallLimit = 14f;
    [SerializeField] private float bottomWallLimit = 41f;

    private float offset = 2f;
    private Rigidbody rb;
    private Vector3 initialPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    private void Update()
    {

        if (GameManager.Instance.State == GameState.PLAY)
        {
            if (ball.transform.position.z > transform.position.z + offset)
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }
            else if (ball.transform.position.z < transform.position.z - offset)
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }

            var positionZ = Mathf.Clamp(transform.position.z, topWallLimit, bottomWallLimit);
            transform.position = new Vector3(transform.position.x, transform.position.y, positionZ);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = initialPosition;
        }
    }
}
