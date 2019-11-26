using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour {
    public PaddleController playerController;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject pausePanel;

    private void Awake() {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        pausePanel.SetActive(false);
    }
    
    public void ShowWinScreen() {
        playerController.GameOver();
        playerController.enabled = false;
        winScreen.SetActive(true);
    }

    public void ShowGameOverScreen() {
        playerController.GameOver();
        playerController.enabled = false;
        loseScreen.SetActive(true);
    }

    public void PauseGame() {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame() {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Replay() {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}