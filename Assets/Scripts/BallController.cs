using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Vector3 serveDirection = Vector3.zero;
    [SerializeField] private float serveStrength = 10f;
    [SerializeField] private float bounceMultiplier = 1.05f;

    [SerializeField] private AudioClip hitSfx;
    [SerializeField] private AudioClip scoreSfx;

    private Rigidbody rb;
    private Vector3 initialPosition;
    private AudioSource audioSrc;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSrc = GetComponent<AudioSource>();
        initialPosition = transform.position;
    }


    private void Update()
    {
        if (GameManager.Instance.State == GameState.SERVE)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce((Random.Range(1, 3) % 2 == 0 ? Vector3.left : Vector3.right) * serveStrength);
                GameManager.SetGameState(GameState.PLAY);
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("PlayerHome"))
        {
            audioSrc.PlayOneShot(scoreSfx);
            GameManager.Instance.onAiScore();
            ResetBall();
        }
        else if (col.gameObject.CompareTag("EnemyHome"))
        {
            audioSrc.PlayOneShot(scoreSfx);
            GameManager.Instance.OnPlayerScore();
            ResetBall();
        }
        else
        {
            if(col.gameObject.CompareTag("Pad"))
                audioSrc.PlayOneShot(hitSfx);

            if (rb.velocity.z == 0)
                rb.AddForce(new Vector3(0, 0, Random.Range(1, 3) % 2 == 0 ? 1 : -1) * serveStrength);

            if (rb.velocity.x > -1f && rb.velocity.x < 1f)
                rb.AddForce(new Vector3(Random.Range(-1f, 1f), 0, 0) * serveStrength);

            // Cuando la pelota rebota con la paleta, aumenta su velocidad
            rb.velocity *= bounceMultiplier;
        }
    }

    private void ResetBall()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = initialPosition;
    }
}
