using System.Collections;
using UnityEngine;

public class SpawnPlanes : MonoBehaviour
{
    [Header("Ayarlar")]
    public float minX = -2f;
    public float maxX = 2f;
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
        while (true)
        {
           
            float rastageleX = Random.Range(minX, maxX);
            Vector3 spawn= new Vector3(rastageleX,sabitY,0);
            int rastgeleobje = Random.Range(0,spawnPlanes.Length);
            GameObject fýrlatýlanobje = Instantiate(spawnPlanes[rastgeleobje], spawn, Quaternion.identity);
            Destroy(fýrlatýlanobje,30);
            yield return new WaitForSeconds(spawnTime);

        }
    }
}
