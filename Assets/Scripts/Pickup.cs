using UnityEngine;

public class Pickup : MonoBehaviour
{
    void FixedUpdate()
    {
        // Realiza un Raycast hacia adelante y comprueba si colisiona con un objeto con el tag "Pickup"
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 1) && hit.collider.CompareTag("Pickup"))
        {
            Debug.DrawRay(transform.position, transform.forward, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward, Color.red); // Dibuja un rayo rojo si no colisiona con "Pickup"
        }
    }
}

