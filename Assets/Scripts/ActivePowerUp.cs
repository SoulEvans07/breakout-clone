using System;

[Serializable]
public class ActivePowerUp {
    public PowerUpObject powerUp;
    public float timer;

	public ActivePowerUp(PowerUpObject powerUp) {
		this.powerUp = powerUp;
		this.timer = powerUp.duration;
	}

    public void Apply(PowerUpHandler handler) {
		powerUp.Apply(handler);
	}

	public void Remove(PowerUpHandler handler) {
		powerUp.Remove(handler);
	}
}
