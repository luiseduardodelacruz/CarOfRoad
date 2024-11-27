using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinishLineTrigger : MonoBehaviour
{
    public TMP_Text winTextPlayer1; // Referencia para el texto de jugador 1
    public TMP_Text winTextPlayer2; // Referencia para el texto de jugador 2

    private void Start()
    {
        // Asegúrate de desactivar ambos textos al inicio
        winTextPlayer1.gameObject.SetActive(false);
        winTextPlayer2.gameObject.SetActive(false);
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
                winTextPlayer1.gameObject.SetActive(true); // Muestra el texto del jugador 1
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
                winTextPlayer2.gameObject.SetActive(true); // Muestra el texto del jugador 2
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
