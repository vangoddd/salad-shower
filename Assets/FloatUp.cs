using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUp : MonoBehaviour
{
  private SpriteRenderer sr;
  private float opacity = 1f;
  // Start is called before the first frame update
  void Start()
  {
    sr = GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  void Update()
  {
    opacity -= Time.deltaTime * 2;
    transform.position += new Vector3(0, Time.deltaTime * 3f, 0);
    sr.color = new Color(1f, 1f, 1f, opacity);
  }
}
