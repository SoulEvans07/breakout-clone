using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PaddleController : MonoBehaviour {
    public GamePlayController _gameController;

    private static float BASE_WIDTH = 33f;

    public float baseBallSpeed = 100f;
    public static float ballSpeed = 100f;
    public static List<GameObject> ballList;
    private float bound;

    private Transform _transform;
    private Rigidbody2D _rigidbody;

    public GameObject ballPrefab;
    public int ballCount = 5;
    public TextMeshProUGUI countText;

    public float speed = 150f;
    private float x;
    private bool gameOver;

    private void Awake() {
        this._transform = transform;
        this._rigidbody = this.GetComponent<Rigidbody2D>();

        ballList = new List<GameObject>();
        ballSpeed = baseBallSpeed;
        gameOver = false;
        
        UpdateBallCountText();
        this.SpawnBall();
    }

    private void Update() {
        if (gameOver) return;
        if (Input.GetButtonUp("Cancel")) _gameController.PauseGame();

        this.x = Input.GetAxis("Horizontal");
        Move();
        
        Vector3 _pos = _transform.position;
        float scaleX = _transform.localScale.x;
        bound = 103f - (BASE_WIDTH * scaleX / 2);
        _transform.position = new Vector3(Mathf.Clamp(_pos.x, -bound, bound), _pos.y, 0);
    }

    private void Move() {
        this._rigidbody.velocity = Vector3.right * this.x * this.speed;
    }

    private void UpdateBallCountText() {
        countText.text = (ballCount + ballList.Count).ToString();
    }

    public GameObject InstantiateBall() {
        GameObject ball = Instantiate(ballPrefab, _transform.position + Vector3.up * 10 + Vector3.right * 0.15f, Quaternion.identity);
        BallController controller = ball.GetComponent<BallController>();
        controller.speed = ballSpeed;
        ballList.Add(ball);
        return ball;
    }

    public void SpawnBall() {
        if (gameOver) return;

        if (ballCount + ballList.Count == 0) {
            _gameController.ShowGameOverScreen();
        } else if (ballList.Count == 0) {
            ballCount--;
            InstantiateBall();
        }
        UpdateBallCountText();
    }

    public void SpawnExtraBall() {
        if (gameOver) return;

        InstantiateBall();
        UpdateBallCountText();
    }

    public void AddExtraBall(int amount) {
        if (gameOver) return;

        this.ballCount += amount;
        UpdateBallCountText();
    }

    public void GameOver() {
        this.gameOver = true;
    }

    public static void MultiplyBallSpeed(float multiplier) {
        float newSpeed = ballSpeed * multiplier;
        ballSpeed *= multiplier;
        if (80 <= newSpeed && newSpeed <= 160) {
            ballSpeed = newSpeed;
        }
    }
}