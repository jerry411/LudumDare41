using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {

    public Toggle fullScreenToggleButton;
    public Dropdown graphicsQualityDropdownButton;

    private void Start()
    {
        fullScreenToggleButton.isOn = Screen.fullScreen;

        graphicsQualityDropdownButton.value = QualitySettings.GetQualityLevel();
    }

    public void ToggleFullScreen(bool newState)
    {
        Screen.fullScreen = newState;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GraphicsQualityChanged(int newQquality)
    {
        QualitySettings.SetQualityLevel(newQquality, true);
    }

    public void ChangeVolume(float newValue)
    {
        AudioListener.volume = newValue;
    }
}
