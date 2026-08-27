using System.Collections;
using UnityEngine;

// Düþman gemilerinin sahnede belirli bir rota üzerinde devriye gezmesini ve düzenli aralýklarla oyuncuya ateþ etmesini yönetiyoruz.
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
        // Düþman gemisi sahneye doðduðu an ateþ etme döngüsünü baþlatýyoruz.
        StartCoroutine(MermiOlustur());
    }
    private void Update()
    {
        // Eðer düþman için belirlenmiþ bir rota dizisi (hedef noktalar) yoksa hata almamak için metodu burada kesiyoruz.
        if (hedefler.Length == 0) return;

        // Gemiyi, rotasýndaki mevcut hedef noktaya doðru belirlediðimiz hýzda pürüzsüzce ilerletiyoruz.
        transform.position = Vector3.MoveTowards(transform.position, hedefler[mevcutýndex].position,harekethýzý*Time.deltaTime);

        // Gemi hedef noktasýna çok yaklaþtýðýnda, dizideki bir sonraki hedef noktasýna geçiþ yapýyoruz.
        if (Vector3.Distance(transform.position, hedefler[mevcutýndex].position) < 0.1f)
        {
            // Eðer gemi dizideki son hedefe ulaþtýysa, endeksi sýfýrlayýp rotanýn baþýna döndürerek sonsuz bir devriye döngüsü kuruyoruz.
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
        // Coroutine ile kurduðumuz sonsuz döngü sayesinde düþmanýn ateþ etme mekaniðini
        // oyun motorunun ana akýþýný yormadan asenkron olarak çalýþtýrýyoruz.
        while (true)
        {
            // Olasý mantýk hatalarýna (sýfýr veya eksi saniyede mermi atma) karþý mermi hýzýný güvenli bir deðere sýfýrlýyoruz.
            if (memrihýzý <= 0.1f)
            {
                memrihýzý = 0.3f;
            }
            // Düþman mermisini tam namlu ucunda  üretiyor ve belirlediðimiz süre kadar bekleyip döngüyü tekrar ediyoruz.
            Instantiate(memriPrefabs, namlu.transform);
            yield return new WaitForSeconds(memrihýzý);
        }
    }
}
