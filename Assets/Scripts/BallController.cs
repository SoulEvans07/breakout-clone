using UnityEngine;

public class BallController : MonoBehaviour {
    private Rigidbody2D _rigidbody;

    public float speed = 9f;
    public Vector3 startVelocity = new Vector3(1, 0, 0);
    [SerializeField] private Vector3 vel;

    private void Awake() {
        this._rigidbody = this.GetComponent<Rigidbody2D>();
        this._rigidbody.velocity = this.startVelocity;
    }

    private void Update() {
        _rigidbody.velocity = _rigidbody.velocity.normalized * speed;
        this.vel = _rigidbody.velocity;
    }
}