using UnityEngine;

public class BrickController : MonoBehaviour {
    static int count = 0;

    public PowerUp powerUp;
    public GameObject powerUpPickupPrefab;

    private void Awake() {
        count++;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ball")) {
            count--;
            Destroy(this.gameObject);
            if (count == 0) {
                Debug.Log("You won!");
            } else if (powerUp != null) {
                GameObject pu = Instantiate(powerUpPickupPrefab, transform.position, Quaternion.identity);
                pu.GetComponent<PowerUpBehavior>().SetPowerUp(powerUp);
            }
        }
    }
}