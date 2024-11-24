using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.CompareTag("player1")) 
        {
            Debug.Log("¡Has cruzado la línea de meta!");

            PlayerControler playerController = other.GetComponent<PlayerControler>();
            if (playerController != null)
            {
                playerController.enabled = false;
            }

        }
    }
}
