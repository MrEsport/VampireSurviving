using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Library")]
    [SerializeField] private List<GameObject> enemiesList;

    [Header("Spawn Data")]
    [SerializeField, MinMaxSlider(5, 25)] private Vector2 radius;
    [SerializeField, MinMaxSlider(0, 20)] private Vector2Int amountPerWave;
    [SerializeField] private float waveInterval;

    [Header("Dependencies")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private ExperienceCounter expCounter;

    private float waveTimer;

    private void Start()
    {
        waveTimer = 1f;
    }

    private void Update()
    {
        waveTimer -= GameplayTime.deltaTime;

        if(waveTimer <= 0f)
        {
            SpawnWave();
            waveTimer += waveInterval;
        }
    }

    private void SpawnWave()
    {
        int waveAmount = Random.Range(amountPerWave.x, amountPerWave.y);
        for (int i = 0; i < waveAmount; ++i)
        {
            SpawnEnemy(enemiesList[Random.Range(0, enemiesList.Count)]);
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector2 spawnPosition = (Vector2)playerTransform.position + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * Random.Range(0f, radius.y - radius.x);

        spawnPosition += (spawnPosition - (Vector2)playerTransform.position).normalized * radius.x;

        var instance = Instantiate(enemy, spawnPosition, Quaternion.identity);

        instance.GetComponent<FollowBrain>().SetTarget(playerTransform);
        var entity = instance.GetComponent<Entity>();

        entity.OnDeath.AddListener(() => expCounter.GainExp(5));
    }

    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(playerTransform.position, radius.y);
        Gizmos.color = Color.green * .7f;
        Gizmos.DrawWireSphere(playerTransform.position, radius.x);
    }
}
