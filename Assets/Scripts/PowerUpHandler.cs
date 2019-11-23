using UnityEngine;

public class PowerUpHandler : MonoBehaviour {
    private Transform _transform;

    private ActivePowerUp activePowerup;
    public PaddleController controller;

    private void Awake() {
        _transform = GetComponent<Transform>();

        activePowerup = null;
    }

    private void Update() {
        if (activePowerup != null) {
            activePowerup.timer -= Time.deltaTime;

            if (activePowerup.timer <= 0f) {
                activePowerup.Remove(this);
                activePowerup.timer = 0f;
                activePowerup = null;
            }
        }
    }

    public void ActivatePowerUp(PowerUp powerUp) {
        if (powerUp.isOverwritable) {
            activePowerup?.Remove(this);
            activePowerup = new ActivePowerUp(powerUp);
        }
        
        powerUp.Apply(this);
    }

    public void AddPaddleLength(float amount) {
        if (_transform.localScale.x + amount <= 6) {
            _transform.localScale = new Vector3(_transform.localScale.x + amount, 1, 1);
        }
    }

    public void AddExtraBall(int amount) {
        controller.AddExtraBall(amount);
    }

    public void EnablePiercingBall(bool enable) {
        foreach (BrickController brick in BrickController.brickList) {
            brick.EnableTrigger(enable);
        }
    }

    public void SpawnExtraBall() {
        controller.SpawnExtraBall();
    }
}