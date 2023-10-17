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
        groundDetector = GetComponent<GroundDetector>(); // Obt�n el componente GroundDetector
    }

    void Update()
    {
        if (groundDetector != null && groundDetector.grounded) // Solo permite mover al jugador si est� en el suelo
        {
            // Obt�n el movimiento del rat�n del eje X
            float mouseX = Input.GetAxis("Mouse X");

            // Calcula la rotaci�n del cuerpo
            Quaternion cuerpoRotation = Quaternion.Euler(0f, mouseX * playerRotationSpeed, 0f);

            // Aplica la rotaci�n al cuerpo
            Quaternion newRotation = transform.rotation * cuerpoRotation;

            transform.rotation = newRotation;

            deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * moveSpeed * Time.deltaTime;
            player.transform.Translate(deltaMove);
        }
    }
}
