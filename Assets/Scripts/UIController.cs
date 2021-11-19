using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI livesTxt;
    [SerializeField]
    private TextMeshProUGUI levelTxt;
    [SerializeField]
    private TextMeshProUGUI musicBtnTxt;
    [SerializeField]
    private TextMeshProUGUI soundBtnTxt;
    [SerializeField]
    private AudioController audioController;

    private void Start()
    {
        UpdateUI();   
    }

    public void SwichMusicOnOff()
    {
        Static.musicOn = !Static.musicOn;
        if (Static.musicOn)
        {
            audioController.SetMusicVolume(0.3f);
        }
        else
        {
            audioController.SetMusicVolume(0.0f);
        }
        UpdateUI();
    }

    public void SwitchSoundOnOff()
    {
        Static.soundOn = !Static.soundOn;
        UpdateUI();
    }

    public void UpdateUI()
    {
        livesTxt.text = $"Lives: {Static.lives}";
        levelTxt.text = $"Level: {Static.level}";
        if (Static.musicOn)
        {
            musicBtnTxt.text = "Music: On";
        }
        else
        {
            musicBtnTxt.text = "Music: Off";
        }
        if (Static.soundOn)
        {
            soundBtnTxt.text = "Sound: On";
        }
        else
        {
            soundBtnTxt.text = "Sound: Off";
        }
    }
}
