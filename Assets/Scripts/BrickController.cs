using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {
    public static List<BrickController> brickList = new List<BrickController>();

    private BoxCollider2D _collider;

    public PowerUpObject powerUp;
    public GameObject powerUpPickupPrefab;

    private void Awake() {
        _collider = GetComponent<BoxCollider2D>();

        brickList.Add(this);
    }

    private void HandleHit() {
        brickList.Remove(this);
        Destroy(this.gameObject);

        if (brickList.Count == 0) {
            Debug.Log("You won!");
        } else if (powerUp != null) {
            GameObject pu = Instantiate(powerUpPickupPrefab, transform.position, Quaternion.identity);
            pu.GetComponent<PowerUpBehavior>().SetPowerUp(powerUp);
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