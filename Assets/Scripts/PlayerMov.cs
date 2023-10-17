using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float playerRotationSpeed;
    public GameObject player;
    public Vector3 deltaMove;
    public float moveSpeed;

    private GroundDetector groundDetector;

    void Start()
    {
        groundDetector = GetComponent<GroundDetector>(); // Obtén el componente GroundDetector
    }

    void Update()
    {
        if (groundDetector != null && groundDetector.grounded) // Solo permite mover al jugador si está en el suelo
        {
            // Obtén el movimiento del ratón del eje X
            float mouseX = Input.GetAxis("Mouse X");

            // Calcula la rotación del cuerpo
            Quaternion cuerpoRotation = Quaternion.Euler(0f, mouseX * playerRotationSpeed, 0f);

            // Aplica la rotación al cuerpo
            Quaternion newRotation = transform.rotation * cuerpoRotation;

            transform.rotation = newRotation;

            deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * moveSpeed * Time.deltaTime;
            player.transform.Translate(deltaMove);
        }
    }
}
