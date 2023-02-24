using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static private GameManager GM;
    public bool spawningEnemies;
    public List<GameObject> enemyList;
    public float enemySpawnTimer;
    public float enemySpawnOffset = 1.5f;

    public BoundsCheck boundsCheck;

    public float respawnDelay = 2;
    private void Awake() {
        GM = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    public IEnumerator SpawnEnemy(){
        while (spawningEnemies)
        {
            yield return new WaitForSeconds(enemySpawnTimer);
            var tempEnemy = Instantiate(enemyList[Random.Range(0, enemyList.Count)]);
            Vector3 pos = Vector3.zero;

            float enemyInset = Mathf.Abs(tempEnemy.GetComponent<BoundsCheck>().radius);
            float xMin = -boundsCheck.camWidth + enemyInset;
            float xMax =  boundsCheck.camWidth - enemyInset;
            pos.x = Random.Range( xMin, xMax );
            pos.y = boundsCheck.camHeight + enemyInset;
            tempEnemy.transform.position = pos;
        }
    }

    public IEnumerator RespawnPlayer(){
        yield return new WaitForSeconds(respawnDelay);
        SceneManager.LoadScene("__Scene_0");

    }
    public static void HERO_DIED(){
        GM.StartCoroutine("RespawnPlayer");
    }
}
