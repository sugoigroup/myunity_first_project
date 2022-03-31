using UnityEngine;
using System.Collections;
using DefaultNamespace;
using TMPro;

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
    private GameObject myId;
    
    [SerializeField]
    private Transform canvasTransform;
    
    [SerializeField]
    private BgmController bgmController;
    [SerializeField]
    private GameObject textBossWarning;
    [SerializeField]
    private GameObject panelBossHp;
    [SerializeField]
    private GameObject boss;


    private void Awake()
    {
        textBossWarning.SetActive(false);
        panelBossHp.SetActive(false);
        boss.SetActive(false);
        StartCoroutine("SpawnEnemy");

    }
    private IEnumerator SpawnEnemy()
    {
        int currentEnemyCount = 0;
        while (true)
        {
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            Vector3 position = new Vector3(positionX,stageData.LimitMax.y - 1.0f, 0.0f);
            GameObject enemyClone = Instantiate(enemyPrefab, position, Quaternion.identity);
            //print("gameID:" + enemyClone.GetInstanceID());
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
        slideClone.GetComponent<EnemyHpViewController>().setOwenerGameObjectId(enemy.GetInstanceID());
        slideClone.SetActive(true);
        
        enemy.GetComponent<Enemy>().setEnemyHpViewController(slideClone.GetComponent<EnemyHpViewController>()) ;
        enemy.SetActive(true);
        
        
        GameObject myEnemyID = Instantiate(myId);
        myEnemyID.transform.SetParent(canvasTransform);
        myEnemyID.transform.localScale = Vector3.one;
        myEnemyID.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
        myEnemyID.SetActive(true);
    }

    private IEnumerator SpawnBoss()
    {
        bgmController.ChangeBgm(BgmType.Boss);
        textBossWarning.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        
        textBossWarning.SetActive(false);
        
        boss.SetActive(true);
        panelBossHp.SetActive(true);
        boss.GetComponent<Boss>().ChangeState(BossState.MoveToAppearPoint);

    }
}
