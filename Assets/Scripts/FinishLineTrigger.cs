using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinishLineTrigger : MonoBehaviour
{
    public TMP_Text winText;

    void Start()
    {
        // Aquí puedes inicializar si lo necesitas
    }

    void Update()
    {
        // Si es necesario agregar lógica en el Update, puedes hacerlo aquí
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el jugador 1 cruzó la meta
        if (other.CompareTag("player1"))
        {
            Debug.Log("¡El jugador 1 ha cruzado la línea de meta!");

            PlayerControler playerController = other.GetComponent<PlayerControler>();
            if (playerController != null)
            {
                playerController.enabled = false; // Desactiva el control del jugador
                winText.gameObject.SetActive(true); // Muestra el texto
                winText.text = "Nivel #1 Completado"; // Muestra el mensaje adecuado
            }

            // Espera un tiempo y luego carga la escena correspondiente para el jugador 1
            StartCoroutine(WaitAndLoadScene("Prototype 2"));
        }

        // Verifica si el jugador 2 cruzó la meta
        if (other.CompareTag("player2"))
        {
            Debug.Log("¡El jugador 2 ha cruzado la línea de meta!");

            PlayerControler playerController = other.GetComponent<PlayerControler>();
            if (playerController != null)
            {
                playerController.enabled = false; // Desactiva el control del jugador
                winText.gameObject.SetActive(true); // Muestra el texto
                winText.text = "Nivel #2 Completado"; // Muestra el mensaje adecuado
            }

            // Espera un tiempo y luego carga la escena correspondiente para el jugador 2
            StartCoroutine(WaitAndLoadScene("Prototype 1"));
        }
    }

    // Método para esperar y cargar la escena
    private IEnumerator WaitAndLoadScene(string sceneName)
    {
        // Espera 3 segundos (puedes ajustar este tiempo)
        yield return new WaitForSeconds(3f);

        // Carga la escena pasada como argumento
        SceneManager.LoadScene(sceneName); // Carga la escena que le pases como parámetro
    }
}
