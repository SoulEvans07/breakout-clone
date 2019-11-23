using UnityEngine;

public class PowerUpAction : MonoBehaviour {
    // Double Length
    public void DoubleLengthApply(PowerUpHandler controller) {
		controller.AddPaddleLength(1);
	}

	public void DoubleLengthRemove(PowerUpHandler controller) {
		controller.AddPaddleLength(-1);
	}

    // Piercing Ball
    public void PiercingBallApply(PowerUpHandler controller) {
		controller.EnablePiercingBall(true);
	}

	public void PiercingBallRemove(PowerUpHandler controller) {
		controller.EnablePiercingBall(false);
	}

    // Extra ball
    public void ExtraBallApply(PowerUpHandler controller) {
		controller.AddExtraBall(1);
	}

    // Spawn Extra ball
    public void SpawnExtraBallApply(PowerUpHandler controller) {
		controller.SpawnExtraBall();
	}
}