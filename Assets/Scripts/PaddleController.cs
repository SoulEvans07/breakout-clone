using UnityEngine;

public class PaddleController : MonoBehaviour {
    private Transform _transform;
    private Rigidbody2D _rigidbody;

    public float speed = 1f;
    private float x;

    private void Awake() {
        this._transform = transform;
        this._rigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        this.x = Input.GetAxis("Horizontal");
        Move();
    }

    private void Move() {
        this._rigidbody.velocity = new Vector3(this.x * this.speed, 0, 0);
    }
}