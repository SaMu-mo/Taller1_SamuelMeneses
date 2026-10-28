using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button botonJugar;
    public Button botonSalir;

    void Start()
    {
        if (botonJugar != null)
        {
            botonJugar.onClick.AddListener(Jugar);
        }

        if (botonSalir != null)
        {
            botonSalir.onClick.AddListener(Salir);
        }
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void Salir()
    {
        Debug.Log("Saliendo del juego");
        Application.Quit();
    }
}