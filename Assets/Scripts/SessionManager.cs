using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SessionManager : MonoBehaviour
{
    [Header("SESSION COUNTERS")]
    public TextMeshProUGUI currentSession;
    public TextMeshProUGUI previousSession;

    [Header("DATE PERSISTENCE")]
    private DataPersistence dataPersistence;

    void Start()
    {
        dataPersistence = FindObjectOfType<DataPersistence>();

        loadCurrentSession();
        loadPreviousSession();
    }

    private void loadCurrentSession()
    {
        if (dataPersistence.HasKey("Current Session"))
        {
            currentSession.text = dataPersistence.GetInt("Current Session").ToString("00");
        }
        else
        {
            dataPersistence.SetInt("Current Session", 0);
            currentSession.text = dataPersistence.GetInt("Current Session").ToString("00");
        }
    }

    public void loadPreviousSession()
    {
        if (dataPersistence.HasKey("Previous Session"))
        {
            previousSession.text = dataPersistence.GetInt("Previous Session").ToString("00");
        }
        else
        {
            dataPersistence.SetInt("Previous", 0);
            previousSession.text = dataPersistence.GetInt("Previous Session").ToString("00");
        }
    }

    public void onLoadScene()
    {
        int temp = dataPersistence.GetInt("Current Session");

        dataPersistence.SetInt("Current Session", temp + 1);
    }


    private void OnApplicationQuit()
    {
        int current = dataPersistence.GetInt("Current Session");

        dataPersistence.SetInt("Previous Session", current);
        dataPersistence.SetInt("Current Session", 0);
    }
}
