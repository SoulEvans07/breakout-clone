using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour {
    private Transform _transform;

    public PaddleController controller;
    public List<ActivePowerUp> activePowerupList;

    private void Awake() {
        _transform = GetComponent<Transform>();

        activePowerupList = new List<ActivePowerUp>();
    }

    private void Update() {
        for (int i = activePowerupList.Count - 1; i >= 0; i--) {
            ActivePowerUp activePowerup = activePowerupList[i];
            activePowerup.timer -= Time.deltaTime;

            if (activePowerup.timer <= 0f) {
                activePowerup.Remove(this);
                activePowerup.timer = 0f;
                activePowerupList.RemoveAt(i);
            }
        }
    }

    public void ActivatePowerUp(PowerUpObject powerUp) {
        activePowerupList.Add(new ActivePowerUp(powerUp));
        powerUp.Apply(this);
    }

    public void AddPaddleLength(float amount) {
        float newSize = _transform.localScale.x + amount;
        if (newSize <= 6 && newSize >= 0.5f) {
            _transform.localScale = new Vector3(newSize, 1, 1);
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