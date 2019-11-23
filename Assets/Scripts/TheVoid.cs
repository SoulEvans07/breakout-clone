using UnityEngine;

public class TheVoid : MonoBehaviour {
    public PaddleController paddle;

    private void OnTriggerEnter2D(Collider2D other) {
        bool isBall = other.CompareTag("Ball");
        bool isPowerup = other.CompareTag("PowerUp");
        
        if (isBall || isPowerup) {
            Destroy(other.gameObject);

            if (isBall) {
                paddle.SpawnBall();
            }
        }
    }
}