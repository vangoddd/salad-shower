using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
  public int health = 3;
  public bool isShield = false;

  public ScoreManagerScript scoreManager;
  public GameObject gameOverPopUp;

  public GameObject bgm;
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
    SoundManagerScript.Instance.Play(4);
    Time.timeScale = 0;
    Destroy(bgm, 0f);
    gameOverPopUp.SetActive(true);

    if (scoreManager.getScore() > PlayerPrefs.GetInt("highscore", 0))
    {
      PlayerPrefs.SetInt("highscore", scoreManager.getScore());
    }
  }
}
