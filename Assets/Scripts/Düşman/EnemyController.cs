using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] hedefler;
    public Transform namlu;
    private float memrihýzý = 0.3f;
    public GameObject memriPrefabs;
    public float harekethýzý = 5f;
    private int mevcutýndex = 0;

    private void Start()
    {
        StartCoroutine(MermiOlustur());
    }
    private void Update()
    {
        if (hedefler.Length == 0) return;

        transform.position = Vector3.MoveTowards(transform.position, hedefler[mevcutýndex].position,harekethýzý*Time.deltaTime);

        if (Vector3.Distance(transform.position, hedefler[mevcutýndex].position) < 0.1f)
        {
            mevcutýndex++;
            if (mevcutýndex >= hedefler.Length)
            {
                mevcutýndex = 0;
                transform.position = hedefler[mevcutýndex].position;
            }
        }
            
    }
    
    IEnumerator MermiOlustur()
    {
        while (true)
        {
            // Güvenlik: Eðer bekleme süresi 0.1'den küçükse, oyun çökmesin diye 1 saniye bekle
            if (memrihýzý <= 0.1f)
            {
                memrihýzý = 0.3f;
            }

            Instantiate(memriPrefabs, namlu.transform);
            yield return new WaitForSeconds(memrihýzý);
        }
    }
}
