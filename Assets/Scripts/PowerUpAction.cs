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

    // Ball Speed Up
    public void BallSpeedUpApply(PowerUpHandler controller) {
        PaddleController.MultiplyBallSpeed(1.6f);
		foreach(GameObject ball in PaddleController.ballList) {
            ball.GetComponent<BallController>().MultiplySpeed(1.6f);
        }
	}

	public void BallSpeedUpRemove(PowerUpHandler controller) {
        PaddleController.MultiplyBallSpeed(0.625f);
		foreach(GameObject ball in PaddleController.ballList) {
            ball.GetComponent<BallController>().MultiplySpeed(0.625f); // 1/1.6 = 0.625
        }
	}

    // Ball Speed Down
    public void BallSpeedDownApply(PowerUpHandler controller) {
        PaddleController.MultiplyBallSpeed(0.625f);
		foreach(GameObject ball in PaddleController.ballList) {
            ball.GetComponent<BallController>().MultiplySpeed(0.625f);
        }
	}

	public void BallSpeedDownRemove(PowerUpHandler controller) {
        PaddleController.MultiplyBallSpeed(1.6f);
		foreach(GameObject ball in PaddleController.ballList) {
            ball.GetComponent<BallController>().MultiplySpeed(1.6f);
        }
	}
}