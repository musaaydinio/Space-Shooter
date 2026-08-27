using UnityEngine;

// Oyuncunun uzay gemisini hareket ettirdiðimiz, ekran sýnýrlarýnýn dýþýna çýkmasýný engellediðimiz
// ve ateþ etme mekaniklerini yönettiðimiz ana kontrolcü sýnýfýmýz.
public class PlayerController : MonoBehaviour
{
    [Header("PlayerMoment")]
    [SerializeField] float moveSpeeds = 5f;
    [SerializeField] float minX = -6f;
    [SerializeField] float maxX = 6f;
    [SerializeField] float minY = -4f;
    [SerializeField] float maxY = 2f;

    [Header("BulletController")]
    [SerializeField] GameObject bulletObje;
    [SerializeField] Transform bulletSpawn;

    private void Update()
    {
        // Oyun duraklatýlmýþsa kontrollerin çalýþmasýný engelliyoruz.
        if (Time.timeScale == 0) return;
        if (Time.timeScale==0)return;
        HareketPos();
        // Farenin sol tuþuna týklandýðýnda ateþ etme fonksiyonunu tetikliyoruz.
        if (Input.GetMouseButtonDown(0))
        {
            BulletCont();
        }    
        
     }

    private void HareketPos()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 hareketvektoru = new Vector3(h, v, 0);
        hareketvektoru = hareketvektoru.normalized;

        // Çapraz gidiþlerde  hem saða hem yukarý basýldýðýnda karakterin normalden hýzlý gitmesini engellemek için vektörü normalize ediyoruz.
        Vector3 clamPos = transform.position;
        clamPos.x = Mathf.Clamp(clamPos.x, minX, maxX);
        clamPos.y = Mathf.Clamp(clamPos.y, minY, maxY);

        // Sýnýrlandýrýlmýþ pozisyonu karaktere uyguladýktan sonra, hareket vektörümüzü hýz ve zamanla çarparak pürüzsüz bir kayma hareketi saðlýyoruz.
        transform.position = clamPos;
        transform.Translate(hareketvektoru * moveSpeeds * Time.deltaTime);
    }
    
    private void BulletCont()
    {
        // Ateþ edildiðinde, mermi prefabýmýzý uzay gemisinin uç kýsmýnda belirlediðimiz bulletSpawn koordinatta sahneye üretiyoruz.
        Instantiate(bulletObje, bulletSpawn.position, Quaternion.identity);
    }
}

