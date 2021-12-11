using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
  public TextMeshProUGUI text;
  public PlayerHealth ph;
  // Start is called before the first frame update
  void Start()
  {
    text = GetComponent<TextMeshProUGUI>();
  }

  // Update is called once per frame
  void Update()
  {
    text.text = "Health : " + ph.getHealth().ToString();
  }
}
