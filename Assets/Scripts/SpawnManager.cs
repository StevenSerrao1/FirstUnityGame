using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private bool _stopSpawning;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawn GameObjects every 5 seconds
    IEnumerator SpawnCoroutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 spawnPosition = new Vector3((Random.Range(-9.0f, 9.0f)), 9.0f, 0.0f);
            GameObject newEnemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5);
        }

        // yield return null; // Waits for 1 Frame
        // then calls the next line
        // yield return new WaitForSeconds(5.7f); // Waits for 5 seconds
        // then calls the next line
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }



}
