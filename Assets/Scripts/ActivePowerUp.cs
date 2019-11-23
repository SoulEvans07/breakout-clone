public class ActivePowerUp {
    public PowerUp powerUp;
    public float timer;

	public ActivePowerUp(PowerUp powerUp) {
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
