using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject assetPrefab; // Unity Editor üzerinden atanacak spawn edilecek obje
    public float spawnYPosition = 5f; // Sabit Y koordinatı
    public float spawnInterval = 10f; // Spawn aralığı (saniye)

    void Start()
    {
        // Belirli aralıklarla SpawnObject fonksiyonunu çağır
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        // -10 ile +10 arasında rastgele bir X koordinatı seç
        float randomXPosition = Random.Range(-0.7650645f, 0.7650645f);
        Vector3 spawnPosition = new Vector3(randomXPosition, spawnYPosition, 0f);
        
        // 'assetPrefab' değişkeni kullanılmalıdır.
        Instantiate(assetPrefab, spawnPosition, Quaternion.identity);
    }
}
