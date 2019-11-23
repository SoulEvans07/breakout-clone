using UnityEngine;

public class PowerUpHandler : MonoBehaviour {
    private ActivePowerUp activePowerup;

    private void Awake() {
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
}