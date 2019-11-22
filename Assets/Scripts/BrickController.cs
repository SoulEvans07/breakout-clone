using UnityEngine;

public class BrickController : MonoBehaviour {
    static int count = 0;

    private void Awake() {
        count++;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ball")) {
            count--;
            Destroy(this.gameObject);
            if (count == 0) {
                Debug.Log("You won!");
            }
        }
    }
}