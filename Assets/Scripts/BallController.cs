using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 0.05f;

    public Vector3 Direction { get; private set; }

    private void Start()
    {
        Direction = new Vector3(1f, 0, 1f);
    }

    private void Update()
    {
        transform.position += Direction * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var normal = collision.contacts[0].normal;
        Direction = Vector3.Reflect(Direction, normal);
    }
}