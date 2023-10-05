using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMov : MonoBehaviour
{

    public float playerRotationSpeed;
    public GameObject player;
    public Vector3 deltaMove;
    public float moveSpeed;

    void Update()
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
