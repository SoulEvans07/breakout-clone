using UnityEngine;

public class MainMenu : MonoBehaviour {
    public GameObject mainMenu;
    public GameObject levelSelector;

    public void Awake() {
        mainMenu.SetActive(true);
        levelSelector.SetActive(false);
    }

    public void BackToMainMenu() {
        mainMenu.SetActive(true);
        levelSelector.SetActive(false);
    }

    public void OpenLevelSelector() {
        mainMenu.SetActive(false);
        levelSelector.SetActive(true);
    }

    public void Quit() {
        Application.Quit();
    }
}