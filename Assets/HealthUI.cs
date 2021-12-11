using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{

  public PlayerHealth ph;
  public PowerUpPlayer pu;
  public GameObject h1, h2, h3;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (pu.getCurPowerUp() == PowerUpPlayer.PowerUp.Shield)
    {
      h1.GetComponent<HeartSprite>().setShield();
      h2.GetComponent<HeartSprite>().setShield();
      h3.GetComponent<HeartSprite>().setShield();
    }
    else
    {
      h1.GetComponent<HeartSprite>().removeShield();
      h2.GetComponent<HeartSprite>().removeShield();
      h3.GetComponent<HeartSprite>().removeShield();
    }
    int health = ph.getHealth();
    if (health == 2)
    {
      h3.SetActive(false);
    }
    else if (health == 1)
    {
      h3.SetActive(false);
      h2.SetActive(false);
    }
  }
}
