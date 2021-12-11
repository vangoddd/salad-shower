using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  public int health = 3;
  public bool isShield = false;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void reduceHealth()
  {
    if (!isShield)
    {
      health -= 1;
    }
    else
    {
      isShield = false;
      GetComponent<PowerUpPlayer>().curPowerUp = PowerUpPlayer.PowerUp.None;
    }

    if (health < 1)
    {
      die();
    }
  }

  public int getHealth()
  {
    return health;
  }

  private void die()
  {
    Debug.Log("player died");
  }
}
