using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class OptionsManager : MonoBehaviour
{
    [Header("OPTIONS UI")]
    public TMP_InputField nicknameUI;
    public TMP_Dropdown difficultyUI;
    public Toggle godmodeUI;
    public TextMeshProUGUI roundsUI;
    public Slider musicVolumeUI;
    public AudioMixer audioMixer;

    [Header("DEFAULT SETTINGS")]
    private string DefaultNickname = "patata23";
    private int DefaultDifficulty = 0;
    private bool DefaultGodmode = false;
    private float DefaultMusicVolume = 0.75f;
    private int DefaultRounds = 3;

    [Header("DATE PERSISTENCE")]
    private DataPersistence dataPersistence;

    private void Start()
    {
        // Obtiene el el script Data Persistence
        dataPersistence = FindObjectOfType<DataPersistence>();

        // Obtiene las opciones guardadas
        LoadSavedSettings();
    }

    // Obtiene todas las opciones guardadas
    private void LoadSavedSettings()
    {
        GetNickname();
        GetDifficulty();
        GetGodmode();
        GetMusicVolume();
        GetRounds();
    }

    // G E T T E R S

    // Obtiene la opcion Nickname guardada
    public void GetNickname()
    {
        // Si no existe, guarda un valor predeterminado
        if (!dataPersistence.HasKey("Nickname"))
        {
            SetNickname(DefaultNickname);
        }

        // Obtiene el valor guardado
        nicknameUI.text = dataPersistence.GetString("Nickname");
    }

    // Obtiene la opcion Difficulty guardada
    public void GetDifficulty()
    {
        // Si no existe, guarda un valor predeterminado
        if (!dataPersistence.HasKey("Difficulty"))
        {
            SetDifficulty(DefaultDifficulty);
        }

        // Obtiene el valor guardado
        difficultyUI.value = dataPersistence.GetInt("Difficulty");
    }

    // Obtiene la opcion Godmode guardada
    public void GetGodmode()
    {
        // Si no existe, guarda un valor predeterminado
        if (!dataPersistence.HasKey("Godmode"))
        {
            SetGodmode(DefaultGodmode);
        }

        // Obtiene el valor guardado
        godmodeUI.isOn = dataPersistence.GetBool("Godmode");
    }

    // Obtiene la opcion Music Volume guardada
    public void GetMusicVolume()
    {
        // Si no existe, guarda un valor predeterminado
        if (!dataPersistence.HasKey("Music Volume"))
        {
            SetMusicVolume(DefaultMusicVolume);
        }

        // Obtiene el valor guardado
        musicVolumeUI.value = dataPersistence.GetFloat("Music Volume");
    }

    // Obtiene la opcion Rounds guardada
    public void GetRounds()
    {
        // Si no existe, guarda un valor predeterminado
        if (!dataPersistence.HasKey("Rounds"))
        {
            SetRounds(DefaultRounds);
        }

        // Obtiene el valor guardado
        roundsUI.text = dataPersistence.GetInt("Rounds").ToString();
    }

    // S E T T E R S

    // Guarda la opcion Nickname con una key
    public void SetNickname(string name)
    {
        dataPersistence.SetString("Nickname", name);
    }

    // Guarda la opcion Difficulty con una key
    public void SetDifficulty(int index)
    {
        dataPersistence.SetInt("Difficulty", index);
    }

    // Guarda la opcion Godmode con una key
    public void SetGodmode(bool mode)
    {
        dataPersistence.SetBool("Godmode", mode);
    }


    // Guarda la opcion Music Volume con una key
    public void SetMusicVolume(float volume)
    {
        // Cambia el volumen de la musica en el AudioMixer
        audioMixer.SetFloat("Music Volume", Mathf.Log10(volume) * 20);

        dataPersistence.SetFloat("Music Volume", volume);
    }

    // Guarda la opcion Rounds con una key
    public void SetRounds(int rounds)
    {
        dataPersistence.SetInt("Rounds", rounds);
    }

    // Añade +1 al número rondas y guarda el valor
    public void AddRounds()
    {
        // Guarda el texto parseado a int y sumado +1
        int temp = int.Parse(roundsUI.text) + 1;

        // Limita el valor de temp entre 1 y 10
        temp = Mathf.Clamp(temp, 1, 10);

        // Actualiza el valor en la UI
        roundsUI.text = temp.ToString();

        // Guarda el valor
        SetRounds(temp);
    }

    // Quita -1 al número rondas y guarda el valor
    public void RemoveRounds()
    {
        // Guarda el texto parseado a int y restado -1
        int temp = int.Parse(roundsUI.text) - 1;

        // Limita el valor entre 1 y 10
        temp = Mathf.Clamp(temp, 1, 10);

        // Actualiza el valor en la UI
        roundsUI.text = temp.ToString();

        // Guarda el valor
        SetRounds(temp);
    }
}