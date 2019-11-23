using UnityEngine;

public class PowerUpAction : MonoBehaviour {
    // Grow Paddle
    public void GrowPaddleApply(PowerUpHandler controller) {
		controller.AddPaddleLength(1);
	}

	public void GrowPaddleRemove(PowerUpHandler controller) {
		controller.AddPaddleLength(-1);
	}

    // Shrink Paddle
    public void ShrinkPaddleApply(PowerUpHandler controller) {
		controller.AddPaddleLength(-0.5f);
	}

	public void ShrinkPaddleRemove(PowerUpHandler controller) {
		controller.AddPaddleLength(0.5f);
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