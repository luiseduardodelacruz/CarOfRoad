using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class FinishLineTrigger : MonoBehaviour
{

    public TMP_Text winText;
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
                winText.gameObject.SetActive(true);  // Muestra el texto
                winText.text = "Nivel #1 Completado";  // Cambia el mensaje
            }


            StartCoroutine(WaitAndLoadScene());



            /*if (winText != null)
            {
                winText.gameObject.SetActive(true);  // Muestra el texto
                winText.text = "Nivel #1 Completado";  // Cambia el mensaje
            }

            // Detener el juego (opcional)
            Time.timeScale = 0f;  // Detiene todo el juego (si lo deseas)
            */
        }
    }

    private IEnumerator WaitAndLoadScene()
    {
        // Espera 3 segundos (puedes ajustar este tiempo)
        yield return new WaitForSeconds(3f);

        // Carga la escena con el nombre que desees (asegúrate de que esté añadida en Build Settings)
        SceneManager.LoadScene("Prototype 2"); // Cambia "NombreDeTuEscena" por el nombre real de la escena
    }
}
