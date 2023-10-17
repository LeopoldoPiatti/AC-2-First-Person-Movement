using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce = 10f;
    public int maxAirJumps = 1; // Máxima cantidad de saltos en el aire permitidos
    private int remainingAirJumps; // Saltos en el aire disponibles

    private GroundDetector groundDetector;

    void Start()
    {
        groundDetector = GetComponent<GroundDetector>();
        remainingAirJumps = maxAirJumps; // Al inicio, asigna la cantidad máxima de saltos en el aire
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (groundDetector.grounded)
            {
                // Si está en el suelo, puede saltar
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                remainingAirJumps = maxAirJumps; // Reinicia los saltos en el aire disponibles
            }
            else if (remainingAirJumps > 0)
            {
                // Si no está en el suelo pero tiene saltos en el aire disponibles, puede saltar
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // Reinicia la velocidad vertical
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                remainingAirJumps--; // Reduce la cantidad de saltos en el aire disponibles
            }
        }
    }
}


