using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarOutBounds : MonoBehaviour
{
    private float resetYPosition = 150f;  // Umbral de Y para detectar ca�da
    private float previousYPosition;
    private Vector3 initialPosition = new Vector3(-9.602f, 159.69f, -130f);  // Posici�n inicial
    private Rigidbody carRigidbody;

    void Start()
    {
        // Guardamos la posici�n inicial en Y
        previousYPosition = transform.position.y;

        // Obt�n el componente Rigidbody si es que el carro tiene uno
        carRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Detectamos si el carro ha ca�do por debajo del l�mite en Y
        if (transform.position.y < resetYPosition)
        {
            // Si la posici�n en Y est� cayendo (la posici�n actual en Y es menor que la anterior)
            if (transform.position.y < previousYPosition)
            {
                Debug.Log("�El carro sali� de los l�mites! Est� cayendo.");

                // Si hay un Rigidbody, desactivamos la gravedad temporalmente para evitar interferencias
                if (carRigidbody != null)
                {
                    carRigidbody.isKinematic = true;  // Evita la interacci�n con la f�sica
                }

                // Reiniciamos la posici�n del carro a la inicial
                transform.position = initialPosition;

                // Rehabilitamos la f�sica
                if (carRigidbody != null)
                {
                    carRigidbody.isKinematic = false;  // Restaura la f�sica normal
                }
            }
        }

        // Actualizamos la posici�n anterior de Y para la pr�xima comparaci�n
        previousYPosition = transform.position.y;
    }
}