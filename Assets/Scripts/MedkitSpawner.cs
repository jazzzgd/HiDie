using UnityEngine;

public class MedkitSpawner : MonoBehaviour
{
    public GameObject medkitPrefab; // префаб аптечки
    public float spawnInterval = 10f; // Интервал в секундах между спавнами
    public float spawnRadius = 10f; // Радиус в котором аптечка может спавнится

    private float timer; // Интервал спавна

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;

            // Генерация рандомной позиции
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;

            // Спавн аптечки в рандомном месте
            Instantiate(medkitPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
