using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerScript : MonoBehaviour
{
  private int playerScore;
  // Start is called before the first frame update
  void Start()
  {
    playerScore = 0;
  }

  // Update is called once per frame
  void Update()
  {
  }

  public void addScore(int score)
  {
    playerScore += score;
  }

  public int getScore()
  {
    return playerScore;
  }
}
