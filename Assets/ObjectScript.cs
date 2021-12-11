using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
  public enum ObjectType { Bomb, Fruit, Shield, Expand, BonusFruit, BonusPU };

  public float fallingSpeed;
  private BoxCollider2D hitbox;

  public List<Sprite> spriteList;
  private SpriteRenderer spriteRenderer;

  public Transform playerHigh, objectLow, ground;
  public ScoreManagerScript scoreManager;

  public PlayerHealth ph;
  public PowerUpPlayer pu;

  public ObjectType objectType = ObjectType.Fruit;
  // Start is called before the first frame update
  void Start()
  {
    playerHigh = GameObject.Find("Player").GetComponentInChildren<Transform>();
    ph = GameObject.Find("Player").GetComponent<PlayerHealth>();
    pu = GameObject.Find("Player").GetComponent<PowerUpPlayer>();

    ground = GameObject.Find("Ground").GetComponent<Transform>();
    spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    hitbox = gameObject.GetComponent<BoxCollider2D>();

    scoreManager = (ScoreManagerScript)GameObject.Find("ScoreManager").GetComponent(typeof(ScoreManagerScript));

    int spriteIndex = Random.Range(0, spriteList.Count);
    spriteRenderer.sprite = spriteList[spriteIndex];
  }

  // Update is called once per frame
  void Update()
  {
    transform.position += new Vector3(0f, -fallingSpeed * Time.deltaTime, 0f);

    if (objectLow.position.y <= ground.position.y)
    {
      if (objectType == ObjectType.Fruit)
      {
        ph.reduceHealth();
      }
      Destroy(gameObject);
    }
  }

  //Collision with player
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player") && (playerHigh.position.y <= objectLow.position.y))
    {
      if (objectType == ObjectType.Fruit || objectType == ObjectType.BonusFruit)
      {
        scoreManager.addScore();
      }
      else if (objectType == ObjectType.Bomb)
      {
        ph.reduceHealth();
      }
      else
      {
        if (objectType == ObjectType.Shield) pu.applyShield();
        else if (objectType == ObjectType.Expand) pu.applyExpand();
        else if (objectType == ObjectType.BonusPU) pu.applyBonus();
      }
      Destroy(gameObject);
    }
  }

  public void setSpeed(float speed)
  {
    fallingSpeed = speed;
  }
}
