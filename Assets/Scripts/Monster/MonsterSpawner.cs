using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [Header("Monsters")]
    [SerializeField]
    private List<GameObject> monsterReference = new List<GameObject>();
    [SerializeField]
    private List<GameObject> FlyingMonsterReference = new List<GameObject>();

    private GameObject spawnedMonster;

    [Header("Spawn Positions")]
    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    private float minVel = 2;
    private float maxVel = 4;

    private float maxTimeSpawn = 7;
    private float minTimeSpawn = 5;
    void Start()
    {
        StartCoroutine(SpawnMonsters());
        StartCoroutine(SpawnMonsters2());
        StartCoroutine(SpawnMonsters3());
    }

    private void Update()
    {
        if(GameManager.instance.timer >= GameManager.instance.maxTimer)
        {
            GameManager.instance.maxTimer += 15f;
            if(minVel <= 2 && maxVel <= 4 && GameManager.instance.maxTimer == 30)
            {
                minVel += 1;
                maxVel += 1;
                minTimeSpawn = 4;
                maxTimeSpawn = 6;
                Debug.Log("1");
            }

            if (minVel <= 3 && maxVel <= 5 && GameManager.instance.maxTimer == 45)
            {
                minVel += 1;
                maxVel += 1;
                minTimeSpawn = 3;
                maxTimeSpawn = 5;
                Debug.Log("2");
            }

            if (minVel <= 4 && maxVel <= 6 && GameManager.instance.maxTimer == 60)
            {
                minVel += 1;
                maxVel += 1;
                minTimeSpawn = 2;
                maxTimeSpawn = 4;
                Debug.Log("3");
            }

            if (minVel <= 6 && maxVel <= 8 && GameManager.instance.maxTimer == 75)
            {
                minVel += 2;
                maxVel += 2;
                minTimeSpawn = 2;
                maxTimeSpawn = 3;
                Debug.Log("4");
            }
        }
    }

    IEnumerator SpawnMonsters()
    {
        while (true) 
        {
            yield return new WaitForSeconds(Random.Range(minTimeSpawn, maxTimeSpawn));

            if (PlayerPrefs.GetInt("Tutorial") == 3)
            {
                randomIndex = Random.Range(0, monsterReference.Count);
                randomSide = Random.Range(0, 2);

                spawnedMonster = Instantiate(monsterReference[randomIndex]);

                if (randomSide == 0)
                {
                    spawnedMonster.transform.position = new Vector3(leftPos.position.x, spawnedMonster.transform.position.y, spawnedMonster.transform.position.z);
                    spawnedMonster.GetComponent<Monster>().speed = Random.Range(minVel, maxVel);  
                }
                else
                {
                    spawnedMonster.transform.position = new Vector3(rightPos.position.x, spawnedMonster.transform.position.y, spawnedMonster.transform.position.z);
                    spawnedMonster.GetComponent<Monster>().speed = -Random.Range(minVel, maxVel);
                    spawnedMonster.transform.localScale = new Vector3(spawnedMonster.transform.localScale.x * -1f, spawnedMonster.transform.localScale.y, 1f);
                }

                for(int i = 0; i < FlyingMonsterReference.Count; i++)
                {
                    if (GameManager.instance.timer >= 10 && monsterReference[monsterReference.Count - 1] != FlyingMonsterReference[i])
                    {
                        monsterReference.Add(FlyingMonsterReference[i]);
                    }
                }
            }  
        } 
    }

    IEnumerator SpawnMonsters2()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeSpawn + 1, maxTimeSpawn + 1));

            if (PlayerPrefs.GetInt("Tutorial") == 3)
            {
                randomIndex = Random.Range(0, monsterReference.Count);
                randomSide = Random.Range(0, 2);

                spawnedMonster = Instantiate(monsterReference[randomIndex]);

                if (randomSide == 0)
                {
                    spawnedMonster.transform.position = new Vector3(leftPos.position.x, spawnedMonster.transform.position.y, spawnedMonster.transform.position.z);
                    spawnedMonster.GetComponent<Monster>().speed = Random.Range(minVel, maxVel);
                }
                else
                {
                    spawnedMonster.transform.position = new Vector3(rightPos.position.x, spawnedMonster.transform.position.y, spawnedMonster.transform.position.z);
                    spawnedMonster.GetComponent<Monster>().speed = -Random.Range(minVel, maxVel);
                    spawnedMonster.transform.localScale = new Vector3(spawnedMonster.transform.localScale.x * -1f, spawnedMonster.transform.localScale.y, 1f);
                }

                for (int i = 0; i < FlyingMonsterReference.Count; i++)
                {
                    if (GameManager.instance.timer >= 10 && monsterReference[monsterReference.Count - 1] != FlyingMonsterReference[i])
                    {
                        monsterReference.Add(FlyingMonsterReference[i]);
                    }
                }
            }
        }
    }

    IEnumerator SpawnMonsters3()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeSpawn + 3, maxTimeSpawn + 3));

            if (PlayerPrefs.GetInt("Tutorial") == 3)
            {
                randomIndex = Random.Range(0, monsterReference.Count);
                randomSide = Random.Range(0, 2);

                spawnedMonster = Instantiate(monsterReference[randomIndex]);

                if (randomSide == 0)
                {
                    spawnedMonster.transform.position = new Vector3(leftPos.position.x, spawnedMonster.transform.position.y, spawnedMonster.transform.position.z);
                    spawnedMonster.GetComponent<Monster>().speed = Random.Range(minVel, maxVel);
                }
                else
                {
                    spawnedMonster.transform.position = new Vector3(rightPos.position.x, spawnedMonster.transform.position.y, spawnedMonster.transform.position.z);
                    spawnedMonster.GetComponent<Monster>().speed = -Random.Range(minVel, maxVel);
                    spawnedMonster.transform.localScale = new Vector3(spawnedMonster.transform.localScale.x * -1f, spawnedMonster.transform.localScale.y, 1f);
                }

                for (int i = 0; i < FlyingMonsterReference.Count; i++)
                {
                    if (GameManager.instance.timer >= 10 && monsterReference[monsterReference.Count - 1] != FlyingMonsterReference[i])
                    {
                        monsterReference.Add(FlyingMonsterReference[i]);
                    }
                }
            }
        }
    }
} 