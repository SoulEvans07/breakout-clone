using UnityEngine;
using TMPro;

public class PaddleController : MonoBehaviour {
    private const float BASE_WIDTH = 33f;
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
        } else {
            Instantiate(ballPrefab, _transform.position + Vector3.up * 10 + Vector3.right * 0.1f, Quaternion.identity);
        }
    }

    public void AddExtraBall(int amount) {
        this.ballCount += amount;
        countText.text = ballCount.ToString();
    }
}