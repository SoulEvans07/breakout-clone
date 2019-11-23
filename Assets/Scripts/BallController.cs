using UnityEngine;

public class BallController : MonoBehaviour {
    private Rigidbody2D _rigidbody;

    public float speed = 100f;

    private void Awake() {
        this._rigidbody = this.GetComponent<Rigidbody2D>();
        this._rigidbody.velocity = Vector2.up * this.speed;
    }

    private void FixedUpdate() {
        _rigidbody.velocity = _rigidbody.velocity.normalized * speed;
    }

    private float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth) {
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            float x = hitFactor(transform.position, other.transform.position, other.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            _rigidbody.velocity = dir * speed;
        }
    }

    public void MultiplySpeed(float multiplier) {
        float newSpeed = speed * multiplier;
        speed *= multiplier;
        if (80 <= newSpeed && newSpeed <= 160) {
            speed = newSpeed;
        }
    }
}