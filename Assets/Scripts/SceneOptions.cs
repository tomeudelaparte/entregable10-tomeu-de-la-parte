using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOptions : MonoBehaviour
{
    [Header("SESSION MANAGER")]
    private SessionManager sessionManager;

    void Start()
    {
        // Obtiene el script Session Manager
        sessionManager = FindObjectOfType<SessionManager>();
    }

    // Carga una scene con el nombre proporcionado
    public void LoadScene(string name)
    {
        // Cuenta el cambio de scene
        sessionManager.sceneChangeCounter();

        // Carga la escena
        SceneManager.LoadScene(name);
    }
}
