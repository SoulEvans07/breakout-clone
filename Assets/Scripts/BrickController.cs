using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {
    private GamePlayController _gameController;
    public static List<BrickController> brickList = new List<BrickController>();

    private BoxCollider2D _collider;
    public BrickDamageHandler _damageHandler;

    public PowerUpObject powerUp;
    public GameObject powerUpPickupPrefab;
    public int hitPoints = 1;
    private int damage = 0;

    private void Awake() {
        _collider = GetComponent<BoxCollider2D>();

        brickList.Add(this);
    }

    public void SetHitPoint(int hitPoints) {
        this.hitPoints = hitPoints;

        if (hitPoints <= 0) {
            _damageHandler.SetUnbreakable();
            brickList.Remove(this);
        }
    }

    public void SetGameController(GamePlayController controller) {
        _gameController = controller;
    }

    private void HandleHit() {
        if (hitPoints <= 0) return;

        damage++;

        if (damage == hitPoints) {
            brickList.Remove(this);
            Destroy(this.gameObject);

            if (brickList.Count == 0) {
                _gameController.ShowWinScreen();
            } else if (powerUp != null) {
                GameObject pu = Instantiate(powerUpPickupPrefab, transform.position, Quaternion.identity);
                pu.GetComponent<PowerUpBehavior>().SetPowerUp(powerUp);
            }
        } else {
            _damageHandler.SetDamage(damage, hitPoints);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ball")) {
            HandleHit();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ball")) {
            HandleHit();
        }
    }

    public void EnableTrigger(bool enable) {
        _collider.isTrigger = enable;
    }
}