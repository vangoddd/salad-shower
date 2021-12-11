using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
  public TextMeshProUGUI text;
  public ScoreManagerScript scoreManager;
  // Start is called before the first frame update
  void Start()
  {
    text = GetComponent<TextMeshProUGUI>();
  }

  // Update is called once per frame
  void Update()
  {
    text.text = scoreManager.getScore().ToString("D6");
  }
}
