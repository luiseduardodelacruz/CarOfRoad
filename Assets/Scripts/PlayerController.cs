using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //variables de manejo
    public float turnSpeed = 0.0f;
    public float speed = 20.0f;
    public float horizontalInput;
    public float forwardInput;

    //variables de camara
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey; 

    //variables multijuador
    public string inputID;

    void Start()
    {
        
    }

    void Update()
    {
        //movimiento del carro
        forwardInput = Input.GetAxis("Vertical" + inputID);
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
  
        //movilidad de vehiculo
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime   * speed * forwardInput);

              // cambio de camara
              if (Input.GetKeyDown(switchKey))
              {
                mainCamera.enabled = !mainCamera.enabled;
                hoodCamera.enabled = !hoodCamera.enabled;
              }
    }
}
