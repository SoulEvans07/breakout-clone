using UnityEngine;

public class TheVoid : MonoBehaviour {
    public PaddleController paddle;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ball")) {
            Destroy(other.gameObject);
            paddle.SpawnBall();
        }
    }
}