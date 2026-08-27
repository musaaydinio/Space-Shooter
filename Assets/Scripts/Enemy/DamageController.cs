using UnityEngine;

// Meteorlarýn fiziksel temas durumlarýný ve oyuncuya hasar verme iþlemlerini kontrol ediyoruz.
public class DamageController : MonoBehaviour
{
    public int hasarmiktarý = 2;
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Oyun bitiþ ekraný aktifken arka planda gerçekleþen çarpýþmalarýn oyuncuya ekstra hasar verip sistem döngüsünü bozmasýný engelliyoruz.
        if (UIManager.instance != null && UIManager.instance.finish != null && UIManager.instance.finish.activeSelf)
        {
            return;
        }

        // Eðer çarpan nesne oyuncuysa, PlayerHealth üzerindeki metoda ulaþýp belirlenen hasarý oyuncunun can havuzundan düþüyoruz.
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.instance.HasarAL(hasarmiktarý);

            Debug.Log("çarpýþma");
             // Oyuncuya hasar veren nesne görevini tamamladýðý için sahneden siliyoruz.
            Destroy(gameObject);
        }
    }
}
