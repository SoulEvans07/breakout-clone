using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour {
    public PaddleController playerController;
    public GameObject winScreen;
    public GameObject loseScreen;

    private void Awake() {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
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

    public void Replay() {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}