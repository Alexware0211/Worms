using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    [Header("Animators")]
    public Animator keybindAnim;
    public Animator optionsAnim;

    [Header("UIGameObjects")]
    public GameObject infoBox;
    public GameObject keybindsInfo;
    public GameObject settingsInfo;
    public GameObject localInfo;

    public void HoverKeybindB()
    {
        infoBox.SetActive(true);
        keybindsInfo.SetActive(true);
    }

    public void HoverLocalB()
    {
        localInfo.SetActive(true);
        infoBox.SetActive(true);
    }

    public void HoverSettingB()
    {
        settingsInfo.SetActive(true);
        infoBox.SetActive(true);
    }

    public void ExitHoverOver()
    {
        infoBox.SetActive(false);
        settingsInfo.SetActive(false);
        keybindsInfo.SetActive(false);
        localInfo.SetActive(false);
    }

    public void OpenKeybinds()
    {
        keybindAnim.SetTrigger("checkKeybinds");
    }

    public void CloseKeybinds()
    {
        keybindAnim.SetTrigger("closeKeybinds");
    }

    public void OpenOptions()
    {
        optionsAnim.SetTrigger("openOptions");
    }

    public void CloseOptions()
    {
        optionsAnim.SetTrigger("closeOptions");
    }

    public void PlayLocalGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    // Known bug : At times the settings / keybinds would just randomly close. If you open one and click on the button again, upon closing the UI it will pop back up. This will repeat if you press more than once.
}
