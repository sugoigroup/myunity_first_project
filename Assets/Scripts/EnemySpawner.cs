using UnityEngine;
using System.Collections;
using DefaultNamespace;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private float maxEnemyCount = 100;
    
    [SerializeField]
    private GameObject enemyHpSliderPrefab;
    
    [SerializeField]
    private Transform canvasTransform;


    private void Awake()
    {
        StartCoroutine("SpawnEnemy");

    }
    private IEnumerator SpawnEnemy()
    {
        int currentEnemyCount = 0;
        while (true)
        {
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            Vector3 position = new Vector3(positionX,stageData.LimitMax.y + 1.0f, 0.0f);
            GameObject enemyClone = Instantiate(enemyPrefab, position, Quaternion.identity);
            SpawnEnemyHpSlider(enemyClone);

            currentEnemyCount++;
            if (currentEnemyCount == maxEnemyCount)
            {
                StartCoroutine("SpawnBoss");
                break;
            }
            
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void SpawnEnemyHpSlider(GameObject enemy)
    {
        GameObject slideClone = Instantiate(enemyHpSliderPrefab);
        slideClone.transform.SetParent(canvasTransform);
        slideClone.transform.localScale = Vector3.one;
        slideClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
        slideClone.GetComponent<EnemyHpViewer>().Setup(enemy.GetComponent<EnemyHp>());
    }

    private IEnumerator SpawnBoss()
    {
        yield return null;
    }
}
