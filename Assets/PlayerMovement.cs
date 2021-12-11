using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private float lastXPos;
  private SpriteRenderer spriteRenderer;
  // Start is called before the first frame update
  void Start()
  {
    lastXPos = transform.position.x;
    spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  void Update()
  {

    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    if (Input.touchCount > 0)
    {
      Touch touch = Input.GetTouch(0);
      worldPosition = Camera.main.ScreenToWorldPoint(touch.position);
    }
    if (worldPosition.x != lastXPos)
    {
      if (worldPosition.x > lastXPos)
      {
        //facing right
        spriteRenderer.flipX = true;
      }
      else
      {
        //facing left
        spriteRenderer.flipX = false;
      }
    }

    transform.position = new Vector3(Mathf.Clamp(worldPosition.x, -8f, 8f), -4, 0);

    lastXPos = worldPosition.x;
  }
}
