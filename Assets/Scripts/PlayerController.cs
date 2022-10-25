using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float topWallLimit = 14f;
    [SerializeField] private float bottomWallLimit = 41f;

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
            var zMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;

            if (transform.position.z > topWallLimit && transform.position.z < bottomWallLimit)
                transform.Translate(0, 0, zMovement);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = initialPosition;
        }
    }
}
