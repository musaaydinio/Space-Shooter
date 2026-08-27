using UnityEngine;

// Oyuncunun ateþlediði merminin hareketini, ekrandan çýkma durumundaki bellek yönetimini ve hedeflerle olan fiziksel çarpýþmalarýný yönetiyoruz.
public class BulletController : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] int hasarmik = 10;
    [SerializeField] GameObject efect;
  
    private void Update()
    {
        // Mermiyi her karede belirlenen hýzda ve pürüzsüz bir þekilde yukarý doðru hareket ettiriyoruz.
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime); 
    }
    private void OnBecameInvisible()
    {
        // Mermi kamera açýsýndan çýktýðý an objeyi yok ederek RAM þiþmesini önlüyoruz.
        Destroy(gameObject);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Mermi bir meteora çarparsa,çarpýþma noktasýna patlama efekti üretiyor, ilgili sesi çalýyor ve hem meteoru hem de mermiyi yok ediyoruz.
        if (other.gameObject.CompareTag("Meteor"))
        {
            Instantiate(efect, transform.position, Quaternion.identity);
            SoundManager.instance.MeteroSound();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        // Mermi bir düþman gemisine çarparsa; düþmanýn üzerindeki can kontrol scriptini bulup hasar fonksiyonuna ulaþýyoruz.
        else if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth dusmanscripti = other.gameObject.GetComponent<EnemyHealth>();
           
            if (dusmanscripti != null)
            {
                dusmanscripti.AlýnanHasar(hasarmik);
            }
            
            Destroy(gameObject);
        }
    }

}
