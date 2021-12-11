using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  public int health = 3;
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
    health -= 1;
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
