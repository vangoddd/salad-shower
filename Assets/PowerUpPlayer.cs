using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPlayer : MonoBehaviour
{
  public enum PowerUp { Shield, None };

  public PlayerHealth ph;
  private float shieldEndTime;
  public float shieldDuration = 20;

  public PowerUp curPowerUp;

  // Start is called before the first frame update
  void Start()
  {
    ph = GetComponent<PlayerHealth>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Time.time > shieldEndTime)
    {
      curPowerUp = PowerUp.None;
      ph.isShield = false;
    }
  }

  public void applyShield()
  {
    curPowerUp = PowerUp.Shield;
    ph.isShield = true;
    shieldEndTime = Time.time + shieldDuration;
  }

  public PowerUp getCurPowerUp()
  {
    return curPowerUp;
  }
}
