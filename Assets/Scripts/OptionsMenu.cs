/*
 * Author: Malcom Goh
 * Date: 30/6/2024
 * Description: Handles options menu functionality for adjusting graphics quality and audio volumes.
 */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public TMP_Dropdown graphics; // Dropdown for selecting graphics quality
    public Slider mastVol, musicVol, sfxVol; // Sliders for master volume, music volume, and SFX volume
    public AudioMixer mainAudioMixer; // Reference to the main audio mixer

    /// <summary>
    /// Changes the graphics quality based on the selected dropdown value.
    /// </summary>
    public void ChangeGraphicsQuality()
    {
        QualitySettings.SetQualityLevel(graphics.value);
    }

    /// <summary>
    /// Changes the master volume based on the slider value.
    /// </summary>
    public void ChangeMasterVolume()
    {
        mainAudioMixer.SetFloat("MasterVol", mastVol.value);
    }

    /// <summary>
    /// Changes the music volume based on the slider value.
    /// </summary>
    public void ChangeMusicVolume()
    {
        mainAudioMixer.SetFloat("musicVol", musicVol.value);
    }

    /// <summary>
    /// Changes the SFX volume based on the slider value.
    /// </summary>
    public void ChangeSFXVolume()
    {
        mainAudioMixer.SetFloat("SFXVol", sfxVol.value);
    }
}
