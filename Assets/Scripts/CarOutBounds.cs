using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarOutBounds : MonoBehaviour
{
    private float resetYPosition = 150f;  // Umbral de Y para detectar caída
    private float previousYPosition;
    private Vector3 initialPosition = new Vector3(-9.602f, 159.69f, -130f);  // Posición inicial
    private Rigidbody carRigidbody;

    void Start()
    {
        // Guardamos la posición inicial en Y
        previousYPosition = transform.position.y;

        // Obtén el componente Rigidbody si es que el carro tiene uno
        carRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Detectamos si el carro ha caído por debajo del límite en Y
        if (transform.position.y < resetYPosition)
        {
            // Si la posición en Y está cayendo (la posición actual en Y es menor que la anterior)
            if (transform.position.y < previousYPosition)
            {
                Debug.Log("¡El carro salió de los límites! Está cayendo.");

                // Si hay un Rigidbody, desactivamos la gravedad temporalmente para evitar interferencias
                if (carRigidbody != null)
                {
                    carRigidbody.isKinematic = true;  // Evita la interacción con la física
                }

                // Reiniciamos la posición del carro a la inicial
                transform.position = initialPosition;

                // Rehabilitamos la física
                if (carRigidbody != null)
                {
                    carRigidbody.isKinematic = false;  // Restaura la física normal
                }
            }
        }

        // Actualizamos la posición anterior de Y para la próxima comparación
        previousYPosition = transform.position.y;
    }
}