
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnEnemy : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnTargets = new List<Transform>();
    private bool inCD = false;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float CD;
    private void Update()
    {
        if (!inCD)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnTargets[Random.Range(0, spawnTargets.Count)]);
            enemy.transform.parent = null;
            StartCoroutine(CDBetweenSpawns());
           
        }
    }
    private IEnumerator CDBetweenSpawns()
    {
        inCD = true;
        yield return new WaitForSeconds(CD);
        inCD = false;
    }
    

}
