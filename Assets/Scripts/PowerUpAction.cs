using UnityEngine;

public class PowerUpAction : MonoBehaviour {
    public void DoubleLengthApply(PowerUpHandler controller) {
		controller.AddPaddleLength(1);
	}

	public void DoubleLengthRemove(PowerUpHandler controller) {
		controller.AddPaddleLength(-1);
	}
}