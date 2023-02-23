using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static private GameManager GM;
    public bool spawningEnemies;
    public List<GameObject> enemyList;
    public float enemySpawnTimer = 0.5f;
    public float enemySpawnOffset = 1.5f;

    public BoundsCheck boundsCheck;
    private void Awake() {
        GM = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }


    IEnumerator SpawnEnemy(){
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
}
