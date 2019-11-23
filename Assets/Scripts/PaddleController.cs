using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaddleController : MonoBehaviour {
    public static List<GameObject> ballList = new List<GameObject>();
    private static float BASE_WIDTH = 33f;
    private float bound;

    private Transform _transform;
    private Rigidbody2D _rigidbody;

    public GameObject ballPrefab;
    public int ballCount = 5;
    public TextMeshProUGUI countText;

    public float speed = 150f;
    private float x;

    private void Awake() {
        this._transform = transform;
        this._rigidbody = this.GetComponent<Rigidbody2D>();
        countText.text = ballCount.ToString();
    }

    private void Start() {
        this.SpawnBall();
    }

    private void Update() {
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

    public void SpawnBall() {
        ballCount--;
        countText.text = ballCount.ToString();
        if (ballCount == 0) {
            Debug.Log("Game Over!");
        } else if (ballList.Count == 0) {
            GameObject ball = Instantiate(ballPrefab, _transform.position + Vector3.up * 10 + Vector3.right * 0.1f, Quaternion.identity);
            ballList.Add(ball);
        }
    }

    public void SpawnExtraBall() {
        ballCount++;
        countText.text = ballCount.ToString();
        GameObject ball = Instantiate(ballPrefab, _transform.position + Vector3.up * 10 + Vector3.right * 0.1f, Quaternion.identity);
        ballList.Add(ball);
    }

    public void AddExtraBall(int amount) {
        this.ballCount += amount;
        countText.text = ballCount.ToString();
    }
}