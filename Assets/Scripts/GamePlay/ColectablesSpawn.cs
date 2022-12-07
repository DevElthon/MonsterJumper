using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectablesSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] colectableReference;
    [SerializeField]
    private GameObject[] coinsObj;

    private GameObject spawnColectable;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnColectables());
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnColectables()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(6, 10));

            if (PlayerPrefs.GetInt("Tutorial") == 3)
            {
                randomIndex = Random.Range(0, colectableReference.Length);
                randomSide = Random.Range(0, 2);

                spawnColectable = Instantiate(colectableReference[randomIndex]);

                if (randomSide == 0)
                {
                    spawnColectable.transform.position = leftPos.position;
                    spawnColectable.GetComponent<Colectable>().speed = Random.Range(4, 10);
                }
                else
                {
                    spawnColectable.transform.position = rightPos.position;
                    spawnColectable.GetComponent<Colectable>().speed = -Random.Range(4, 10);
                    spawnColectable.transform.localScale = new Vector3(spawnColectable.transform.localScale.x, spawnColectable.transform.localScale.y, spawnColectable.transform.localScale.z);
                }
            }
        }
    }

    IEnumerator SpawnCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(6, 10));
            if (PlayerPrefs.GetInt("Tutorial") == 3)
            {
                int RandomCoin = Random.Range(0, coinsObj.Length);
                randomSide = Random.Range(0, 2);
                spawnColectable = Instantiate(coinsObj[RandomCoin]);

                if (randomSide == 0)
                {
                    spawnColectable.transform.position = leftPos.position;
                    spawnColectable.GetComponent<Colectable>().speed = Random.Range(4, 10);
                }
                else
                {
                    spawnColectable.transform.position = rightPos.position;
                    spawnColectable.GetComponent<Colectable>().speed = -Random.Range(4, 10);
                    spawnColectable.transform.localScale = new Vector3(spawnColectable.transform.localScale.x, spawnColectable.transform.localScale.y, spawnColectable.transform.localScale.z);
                }
            }   
        }
    } 
}
