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

  public List<GameObject> puPrefab;

  private int bombCounter = 0;
  public int bombInterval = 2;

  public float puInterval = 5;
  private float puCounter = 0;
  // Start is called before the first frame update
  void Start()
  {
    lastTime = Time.time;
  }

  // Update is called once per frame
  void Update()
  {
    puCounter += Time.deltaTime;
    if (puCounter >= puInterval)
    {
      GameObject pu = Instantiate(puPrefab[Random.Range(0, puPrefab.Count)], new Vector3(Random.Range(-8f, 8f), 5, 0), Quaternion.identity);
      pu.GetComponent<ObjectScript>().setSpeed(fallSpeed);
      puCounter = 0;
    }
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
