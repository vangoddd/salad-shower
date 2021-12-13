using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawnerScript : MonoBehaviour
{
  public float spawnInterval; //in seconds
  public float fallSpeed; //in float

  private float lastTime;
  public GameObject fruitPrefab;
  public GameObject bombPrefab;
  public GameObject bonusFruitPrefab;

  public GameObject explotionPrefab;

  public List<GameObject> puPrefab;

  private int bombCounter = 0;
  public int bombInterval = 2;

  public float puInterval = 5;
  private float puCounter = 0;

  private float delayCounter = 0f;

  private float bonusTimeCounter = 0f;
  private float bonusFruitInterval;

  private float delay = 0f;

  private float timeSinceStart = 0f;

  float worldScreenHeight, worldScreenWidth, padding;

  // Start is called before the first frame update
  void Start()
  {
    lastTime = Time.time;

    worldScreenHeight = Camera.main.orthographicSize * 2f;
    worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
    padding = 0.5f;
  }

  bool shouldSpawnBomb(float chance)
  {
    return Random.Range(0f, 100f) < chance;
  }

  // Update is called once per frame
  void Update()
  {
    //Increasing speed logic
    timeSinceStart += Time.deltaTime;
    spawnInterval = Mathf.Lerp(1.667f, 0.3f, timeSinceStart / 60);
    fallSpeed = Mathf.Lerp(3f, 11f, timeSinceStart / 60);

    //Spawning Logic
    if (Time.time < delayCounter)
    {
      bonusTimeCounter += Time.deltaTime;
      if (bonusTimeCounter >= bonusFruitInterval)
      {
        Debug.Log("spawning Bonus fruit");
        GameObject bFruit = Instantiate(bonusFruitPrefab, new Vector3(Random.Range(-(worldScreenWidth / 2) + padding, (worldScreenWidth / 2) - padding), 5, 0), Quaternion.identity);
        bFruit.GetComponent<ObjectScript>().setSpeed(fallSpeed);
        bonusTimeCounter = 0f;
      }

      return;
    }
    puCounter += Time.deltaTime;
    if (puCounter >= puInterval)
    {
      int choice = Random.Range(0, puPrefab.Count);
      GameObject pu = Instantiate(puPrefab[choice], new Vector3(Random.Range(-(worldScreenWidth / 2) + padding, (worldScreenWidth / 2) - padding), 5, 0), Quaternion.identity);
      pu.GetComponent<ObjectScript>().setSpeed(fallSpeed);

      delay += spawnInterval;

      puCounter = 0;
    }
    if (Time.time - lastTime >= spawnInterval + delay)
    {
      delay = 0;
      GameObject temp;
      lastTime = Time.time;
      if (shouldSpawnBomb(33))
      {
        Debug.Log("spawning bomb");
        temp = Instantiate(bombPrefab, new Vector3(Random.Range(-(worldScreenWidth / 2) + padding, (worldScreenWidth / 2) - padding), 5, 0), Quaternion.identity);
        bombCounter = 0;
      }
      else
      {
        Debug.Log("spawning fruit");
        temp = Instantiate(fruitPrefab, new Vector3(Random.Range(-(worldScreenWidth / 2) + padding, (worldScreenWidth / 2) - padding), 5, 0), Quaternion.identity);
        bombCounter++;
      }
      temp.GetComponent<ObjectScript>().setSpeed(fallSpeed);
    }
  }

  public void applyBonus(float dur)
  {
    delayCounter = Time.time + dur;
    bonusFruitInterval = dur / 50f;
    delay = dur + spawnInterval;
  }
}
