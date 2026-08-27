using UnityEngine;

// Düþman gemilerinden ateþlenen mermilerin oyuncuya doðru hareketini ve isabet anýndaki hasar aktarýmýný kontrol ediyoruz.
public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float mermihýzý = 5f;
    [SerializeField] int hasarMiktarý = 5;

    private void Update()
    {
        // Düþman mermisini oyuncunun bulunduðu alt tarafa doðru sürekli hareket ettiriyoruz.
        transform.Translate(Vector3.down * mermihýzý * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        // Optimizasyon amacýyla, hedefi ýskalayýp ekran dýþýna çýkan düþman mermilerini sahnede tutmayýp siliyoruz.
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Düþman mermisi playera temas ederse, Singleton mimarisiyle PlayerHealth sýnýfýna ulaþýp hasar deðerini iletiyoruz.
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.instance.HasarAL(hasarMiktarý);
        }
    }

}
