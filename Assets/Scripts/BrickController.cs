using UnityEngine;

public class BrickController : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ball")) {
            Destroy(this.gameObject);
        }
    }
}