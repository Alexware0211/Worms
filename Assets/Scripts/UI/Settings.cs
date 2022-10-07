using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{

    

    [Header("Gameobjects")]
    public Image musicFiller;
    public Image sfxFiller;
    public Text modeText;
    public Text resText;
    public Toggle fullscreenTog;


    [Header("Audio")]
    public AudioMixer masterMixer;

    float _musicVolume = 0;
    float _sfxVolume = 0;

    public List<resItem> resolutions = new List<resItem>();
    private int _selectedResolution;


    public void Start()
    {

        //fullscreenTog.isOn = Screen.fullScreen;

        bool _foundRes = false;
        for(int i = 0; i < resolutions.Count; i++)
        {
            if(Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                _foundRes = true;

                _selectedResolution = i;

                UpdateResLable();
            }
        }

        if (!_foundRes)
        {
            resItem newRes = new resItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;


            resolutions.Add(newRes);
            _selectedResolution = resolutions.Count - 1;

            UpdateResLable();
        }
    }

    public void Update()
    {
        if (_musicVolume > 0)
        {
            _musicVolume = 0;
            musicFiller.fillAmount = 1f;
        }
        if (_musicVolume < -40)
        {
            _musicVolume = -40;
            musicFiller.fillAmount = 0f;
        }

        if (_sfxVolume > 0)
        {
            _sfxVolume = 0;
            musicFiller.fillAmount = 1f;
        }
        if (_sfxVolume < -40)
        {
            _sfxVolume = -40;
            musicFiller.fillAmount = 0f;
        }

        

    }

    public void IncreaseMusic()
    {
        _musicVolume += 5;
        masterMixer.SetFloat("bgm", _musicVolume);
        musicFiller.fillAmount += 0.1f;
    }

    public void DecreaseMusic()
    {
        _musicVolume -= 5;
        masterMixer.SetFloat("bgm", _musicVolume);
        musicFiller.fillAmount -= 0.1f;
    }

    public void IncreaseSFX()
    {
        _sfxVolume += 5;
        masterMixer.SetFloat("sfx", _sfxVolume);
        sfxFiller.fillAmount += 0.1f;
    }

    public void DecreaseSFX()
    {
        _sfxVolume -= 5;
        masterMixer.SetFloat("sfx", _sfxVolume);
        sfxFiller.fillAmount -= 0.1f;
    }  

    public void ResLeft()
    {
        _selectedResolution--;

        if (_selectedResolution < 0)
        {
            _selectedResolution = 0;
        }

        UpdateResLable();
    }

    public void ResRight()
    {
        _selectedResolution++;

        if (_selectedResolution > resolutions.Count - 1)
        {
            _selectedResolution = resolutions.Count - 1;
        }

        UpdateResLable();
    }
    
    public void UpdateResLable()
    {
        resText.text = resolutions[_selectedResolution].horizontal.ToString() + " x " + resolutions[_selectedResolution].vertical.ToString();
    }

    public void ApplyGraphics()
    {
        Screen.SetResolution(resolutions[_selectedResolution].horizontal, resolutions[_selectedResolution].vertical, fullscreenTog.isOn);
    }

}

[System.Serializable]
public class resItem
{
    public int  horizontal, vertical;
}
