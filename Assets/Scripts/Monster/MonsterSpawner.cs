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

    private int minVel = 2;
    private int maxVel = 4;

    private void Awake()
    {
        for(int i = 0; i < FlyingMonsterReference.Count; i++)
        {
            FlyingMonsterReference[i].transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1.85f, this.transform.position.z);
        }    
    }

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    private void Update()
    {
        if(GameManager.instance.timer >= GameManager.instance.maxTimer)
        {
            GameManager.instance.maxTimer += 10f;
            if(minVel <= 10 && maxVel <= 14)
            {
                minVel += 2;
                maxVel += 3;
            }
        }
    }

    IEnumerator SpawnMonsters()
    {
        while (true) 
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

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
                spawnedMonster.transform.localScale = new Vector3(spawnedMonster.transform.localScale.x  * - 1f, spawnedMonster.transform.localScale.y, 1f);
            }

            if(GameManager.instance.timer >= 15 && monsterReference[monsterReference.Count - 1] != FlyingMonsterReference[0])
            {
                monsterReference.Add(FlyingMonsterReference[0]);
            }
        } 
    }
} 






























