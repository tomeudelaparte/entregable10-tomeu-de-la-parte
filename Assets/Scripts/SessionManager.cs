using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SessionManager : MonoBehaviour
{
    [Header("SCENE COUNTERS UI")]
    public TextMeshProUGUI currentSession;
    public TextMeshProUGUI previousSession;

    [Header("DATE PERSISTENCE")]
    private DataPersistence dataPersistence;

    void Start()
    {
        // Obtiene el el script Data Persistence
        dataPersistence = FindObjectOfType<DataPersistence>();

        // Obtiene el número de veces la Sesion Actual y de la Sesion Anterior
        loadCurrentSession();
        loadPreviousSession();
    }

    // Obtiene el número de veces de la Sesion Actual
    private void loadCurrentSession()
    {
        // Comprueba si el valor esta guardado mediante una key
        if (dataPersistence.HasKey("Current Session"))
        {
            // Obtiene el valor guardado
            currentSession.text = dataPersistence.GetInt("Current Session").ToString("00");
        }
        else
        {
            // Guarda un valor predeterminado
            dataPersistence.SetInt("Current Session", 0);

            // Obtiene el valor guardado
            currentSession.text = dataPersistence.GetInt("Current Session").ToString("00");
        }
    }

    // Obtiene el número de veces de la Sesion Anterior
    public void loadPreviousSession()
    {
        // Comprueba si el valor esta guardado mediante una key
        if (dataPersistence.HasKey("Previous Session"))
        {
            // Obtiene el valor guardado
            previousSession.text = dataPersistence.GetInt("Previous Session").ToString("00");
        }
        else
        {
            // Guarda un valor predeterminado
            dataPersistence.SetInt("Previous", 0);

            // Obtiene el valor guardado
            previousSession.text = dataPersistence.GetInt("Previous Session").ToString("00");
        }
    }

    // Guarda el número de veces de la Sesion Actual sumando +1
    public void sceneChangeCounter()
    {
        // Obtiene el valor guardado
        int temp = dataPersistence.GetInt("Current Session");

        // Guarda el valor de la Sesion Actual + 1
        dataPersistence.SetInt("Current Session", temp + 1);
    }

    // Al cerrar la aplicacion
    private void OnApplicationQuit()
    {
        // Obtiene el valor de la Sesion Actual
        int current = dataPersistence.GetInt("Current Session");

        // Guarda el valor de la Sesion Actual como Sesion Anterior
        dataPersistence.SetInt("Previous Session", current);

        // Reinicia el valor de la Sesion Actual a 0
        dataPersistence.SetInt("Current Session", 0);
    }
}
