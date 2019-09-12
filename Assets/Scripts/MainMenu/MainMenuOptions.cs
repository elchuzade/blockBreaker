using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuOptions : MonoBehaviour
{
    public Text SoundButtonText;
    public Text HapticButtonText;

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SoundToggle()
    {
        if (PlayerPrefs.GetString("sound", "on") == "on")
        {
            PlayerPrefs.SetString("sound","off");
            SoundButtonText.text = "SOUND OFF";
        } else
        {
            PlayerPrefs.SetString("sound", "on");
            SoundButtonText.text = "SOUND ON";
        }
    }

    public void HapticToggle()
    {
        if (PlayerPrefs.GetString("haptic", "on") == "on")
        {
            PlayerPrefs.SetString("haptic", "off");
            HapticButtonText.text = "HAPTIC OFF";
        }
        else
        {
            PlayerPrefs.SetString("haptic", "on");
            HapticButtonText.text = "HAPTIC ON";
        }
    }
}
