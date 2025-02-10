// filepath: /c:/Users/nicoX/Rollaball/Assets/Scripts/CameraControllerThirdPerson.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Reference to the player GameObject.
    public GameObject player;
    // The distance between the camera and the player.
    private Vector3 offset;
    // Sensibilidad del ratón
    public float mouseSensitivity = 100.0f;
    private float yRotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the player reference is set
        if (player == null)
        {
            Debug.LogError("Player GameObject is not assigned in the CameraController script.");
            return;
        }

        // Calculate the initial offset between the camera's position and the player's position.
        offset = transform.position - player.transform.position;

        // Ocultar y bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    // LateUpdate is called once per frame after all Update functions have been completed.
    void LateUpdate()
    {
        // Ensure the player reference is set
        if (player == null)
        {
            return;
        }

        // Obtener el movimiento del ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;

        // Rotar el jugador en el eje Y (horizontal)
        player.transform.Rotate(Vector3.up * mouseX);

        // Mantener el mismo desplazamiento entre la cámara y el jugador durante todo el juego.
        transform.position = player.transform.position + offset;

        // Rotar la cámara alrededor del jugador
        transform.LookAt(player.transform.position);
    }
}