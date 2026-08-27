using System.Collections;
using UnityEngine;

public class SpawnPlanes : MonoBehaviour
{
    // Uzay boþluðu hissiyatýný artýrmak için arka planda sürekli olarak rastgele gezegenler veya dekoratif objeler üretiyoruz.
    [Header("Ayarlar")]
    public float minX = -6f;
    public float maxX = 6f;
    public float sabitY = 6f;
    public float spawnTime = 5f;

    [Header("SpawnPrefab")]
    public GameObject[] spawnPlanes;

    private void Start()
    {
        StartCoroutine(GezegenFýrlatRoutine());
    }
    IEnumerator GezegenFýrlatRoutine()
    {
        // Oyun devam ettiði sürece çalýþacak sonsuz bir döngü kuruyoruz.
        while (true)
        {
            // Objeyi X ekseninde belirlediðimiz sýnýrlar içerisinde rastgele bir koordinatta oluþturuyoruz.
            float rastageleX = Random.Range(minX, maxX);
            Vector3 spawn= new Vector3(rastageleX,sabitY,0);

            // Prefab dizimizden rastgele bir obje seçip sahneye dahil ediyoruz.
            int rastgeleobje = Random.Range(0,spawnPlanes.Length);
            GameObject fýrlatýlanobje = Instantiate(spawnPlanes[rastgeleobje], spawn, Quaternion.identity);

            // Üretilen objenin sonsuza kadar sahnede kalýp RAM'i þiþirmesini engellemek için 30 saniye sonra yok edilmesini  emrediyoruz.
            Destroy(fýrlatýlanobje,30);
            yield return new WaitForSeconds(spawnTime);

        }
    }
}
