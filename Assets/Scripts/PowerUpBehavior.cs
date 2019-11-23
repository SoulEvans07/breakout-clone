using UnityEngine;

public class PowerUpBehavior : MonoBehaviour {
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    private PowerUpHandler handler;

    [SerializeField]
    private PowerUp powerUp;

    public float speed = 10f;

    private void Awake() {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _renderer = this.GetComponent<SpriteRenderer>();
        _rigidbody.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        bool isPlayer = other.CompareTag("Player");

        if (isPlayer) {
            handler = other.GetComponent<PowerUpHandler>();

            Destroy(this.gameObject);
            ApplyPowerUp();
        }
    }

    public void SetPowerUp(PowerUp pu) {
        this.powerUp = pu;
        this.gameObject.name = pu.name;
        _renderer.color = pu.color;
    }

    public void ApplyPowerUp() {
        handler.ActivatePowerUp(powerUp);
    }
}