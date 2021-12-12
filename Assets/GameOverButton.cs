using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
  public void retryButton()
  {
    Time.timeScale = 1;
    SceneManager.LoadScene(1);
  }

  public void homeButton()
  {
    Time.timeScale = 1;
    SceneManager.LoadScene(0);
  }
}
