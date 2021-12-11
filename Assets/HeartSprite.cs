using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSprite : MonoBehaviour
{
  public List<Sprite> sprites;
  public Image image;
  // Start is called before the first frame update
  void Start()
  {
    image = GetComponent<Image>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void setShield()
  {
    image.sprite = sprites[1];
  }

  public void removeShield()
  {
    image.sprite = sprites[0];
  }
}
