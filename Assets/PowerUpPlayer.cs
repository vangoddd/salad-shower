using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPlayer : MonoBehaviour
{
  public enum PowerUp { Shield, Expand, None };

  public PlayerHealth ph;
  private float puEndTime;
  public float puDuration = 20;

  public PowerUp curPowerUp;

  private BoxCollider2D playerCollider;
  private Vector2 colliderSize;

  // Start is called before the first frame update
  void Start()
  {
    curPowerUp = PowerUp.None;
    ph = GetComponent<PlayerHealth>();
    playerCollider = GetComponent<BoxCollider2D>();
    colliderSize = playerCollider.size;
  }

  // Update is called once per frame
  void Update()
  {
    if (Time.time > puEndTime)
    {
      curPowerUp = PowerUp.None;
      ph.isShield = false;
      playerCollider.size = new Vector2(1.6f, colliderSize.y);
    }
  }

  public void applyShield()
  {
    curPowerUp = PowerUp.Shield;
    ph.isShield = true;
    puEndTime = Time.time + puDuration;
  }

  public void applyExpand()
  {
    curPowerUp = PowerUp.Expand;
    puEndTime = Time.time + puDuration;
    playerCollider.size = new Vector2(2.6f, colliderSize.y);
  }

  public PowerUp getCurPowerUp()
  {
    return curPowerUp;
  }
}
