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
        dataPersistence = FindObjectOfType<DataPersistence>();

        if (dataPersistence.HasKey("Nickname"))
        {
            LoadSavedSettings();
        }
        else
        {
            LoadDefaultSettings();
        }
    }

    private void LoadSavedSettings()
    {
        GetNickname();
        GetDifficulty();
        GetGodmode();
        GetMusicVolume();
        GetRounds();
    }

    private void LoadDefaultSettings()
    {
        SetNickname(DefaultNickname);
        GetNickname();

        SetDifficulty(DefaultDifficulty);
        GetDifficulty();

        SetGodmode(DefaultGodmode);
        GetGodmode();

        SetMusicVolume(DefaultMusicVolume);
        GetMusicVolume();

        SetRounds(DefaultRounds);
        GetRounds();
    }

    // G E T T E R S
    public void GetNickname()
    {
        nicknameUI.text = dataPersistence.GetString("Nickname");
    }

    public void GetDifficulty()
    {
        difficultyUI.value = dataPersistence.GetInt("Difficulty");
    }

    public void GetGodmode()
    {
        godmodeUI.isOn = dataPersistence.GetBool("Godmode");
    }

    public void GetMusicVolume()
    {
        musicVolumeUI.value = dataPersistence.GetFloat("Music Volume");
    }

    public void GetRounds()
    {
        roundsUI.text = dataPersistence.GetInt("Rounds").ToString();
    }

    // S E T T E R S
    public void SetNickname(string name)
    {
        dataPersistence.SetString("Nickname", name);
    }

    public void SetDifficulty(int index)
    {
        dataPersistence.SetInt("Difficulty", index);
    }

    public void SetGodmode(bool mode)
    {
        dataPersistence.SetBool("Godmode", mode);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music Volume", Mathf.Log10(volume) * 20);

        dataPersistence.SetFloat("Music Volume", volume);
    }

    public void SetRounds(int rounds)
    {
        dataPersistence.SetInt("Rounds", rounds);
    }

    public void AddRounds()
    {
        int temp = int.Parse(roundsUI.text) + 1;

        temp = Mathf.Clamp(temp, 1, 10);

        roundsUI.text = temp.ToString();

        SetRounds(temp);
    }

    public void RemoveRounds()
    {
        int temp = int.Parse(roundsUI.text) - 1;

        temp = Mathf.Clamp(temp, 1, 10);

        roundsUI.text = temp.ToString();

        SetRounds(temp);
    }
}