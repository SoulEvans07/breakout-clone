using UnityEngine;
using TMPro;

public class PaddleController : MonoBehaviour {
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

    private void Update() {
        this.x = Input.GetAxis("Horizontal");
        Move();
    }

    private void Move() {
        this._rigidbody.velocity = Vector3.right * this.x * this.speed;
    }

    public void SpawnBall() {
        ballCount--;
        countText.text = ballCount.ToString();
        if (ballCount == 0) {
            Debug.Log("Game Over!");
        } else {
            Instantiate(ballPrefab, _transform.position + Vector3.up * 10 + Vector3.right * 0.1f, Quaternion.identity);
        }
    }
}