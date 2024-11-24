using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarOutBounds : MonoBehaviour
{
    private Vector3 initialPosition = new Vector3(-9.602f, 159.69f, -130f); 
    private float resetYPosition = 150f;  


    
    private bool hasReset = false;

    
    void Update()
    {
        
        if (transform.position.y < resetYPosition && !hasReset)
        {
            Debug.Log("¡El carro salió de los límites! Reiniciando posición.");
            transform.position = initialPosition;  
            hasReset = true; 
        }
    }
}
