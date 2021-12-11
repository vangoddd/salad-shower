using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
  public List<Sprite> spriteList;
  private SpriteRenderer spriteRenderer;
  private PowerUpPlayer pu;
  // Start is called before the first frame update
  void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    pu = GetComponent<PowerUpPlayer>();
  }

  // Update is called once per frame
  void Update()
  {
    if (pu.getCurPowerUp() == PowerUpPlayer.PowerUp.Shield)
    {
      spriteRenderer.sprite = spriteList[1];
    }
    else if (pu.getCurPowerUp() == PowerUpPlayer.PowerUp.Expand)
    {
      spriteRenderer.sprite = spriteList[2];
    }
    else if (pu.getCurPowerUp() == PowerUpPlayer.PowerUp.Bonus)
    {
      spriteRenderer.sprite = spriteList[3];
    }
    else
    {
      spriteRenderer.sprite = spriteList[0];
    }
  }
}
