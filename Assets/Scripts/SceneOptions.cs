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
        sessionManager = FindObjectOfType<SessionManager>();
    }

    public void LoadScene(string name)
    {
        sessionManager.onLoadScene();

        SceneManager.LoadScene(name);
    }
}
