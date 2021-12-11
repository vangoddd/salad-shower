using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawnerScript : MonoBehaviour
{
  public float spawnInterval;
  public float fallSpeed;

  private float lastTime;
  public GameObject fruitPrefab;
  public GameObject bombPrefab;

  private int bombCounter = 0;
  public int bombInterval = 2;
  // Start is called before the first frame update
  void Start()
  {
    lastTime = Time.time;
  }

  // Update is called once per frame
  void Update()
  {
    if (Time.time - lastTime >= spawnInterval)
    {
      GameObject temp;
      lastTime = Time.time;
      if (bombCounter == bombInterval)
      {
        Debug.Log("spawning bomb");
        temp = Instantiate(bombPrefab, new Vector3(Random.Range(-8f, 8f), 5, 0), Quaternion.identity);
        bombCounter = 0;
      }
      else
      {
        Debug.Log("spawning fruit");
        temp = Instantiate(fruitPrefab, new Vector3(Random.Range(-8f, 8f), 5, 0), Quaternion.identity);
        bombCounter++;
      }
      temp.GetComponent<ObjectScript>().setSpeed(fallSpeed);
    }
  }
}
