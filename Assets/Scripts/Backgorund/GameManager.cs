
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// Oyunun temel ilerleyiþ mantýðýný, sahnede hayatta kalan düþman sayýsýný,level geçiþlerini ve oyunun kazanýlma durumunu merkezi olarak yönetiyoruz.
public class GameManager : MonoBehaviour
{
    // GameManager'a her yerden tek bir referansla ulaþabilmek için Singleton deseni oluþturuyoruz.
    public static GameManager instance;
    public List<GameObject> düsmanlar;

    [Header("Geçiþ Ayarlarý")]
    public GameObject gecisPaneli;
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Bölüm baþladýðýnda sahnedeki tüm düþmanlarý "Enemy" etiketinden (Tag) bulup bir listeye kaydediyoruz.
        // Böylece o bölümdeki hedef sayýmýzý belirliyoruz.
        GameObject[] dusmanlardizi = GameObject.FindGameObjectsWithTag("Enemy");
        düsmanlar = new List<GameObject>(dusmanlardizi);
    }

    public void DusmanýYokEt(GameObject obj)
    {
        // Vurulan düþman gemilerini hayatta kalanlar listesinden çýkartýyoruz.
        if (düsmanlar.Contains(obj))
        {
            düsmanlar.Remove(obj);
        }

        // Eðer listede hiç düþman kalmadýysa bir sonraki aþamaya geçiþ sürecini baþlatýyoruz.
        if (düsmanlar.Count == 0)
            if (düsmanlar.Count == 0)
        {
            StartCoroutine(SahneGecisSureci());
        }
    }


    IEnumerator SahneGecisSureci()
    {
        // Bölüm bittiðinde ani bir ekran deðiþimi olmamasý için araya görsel bir geçiþ paneli koyuyoruz.
        if (gecisPaneli != null)
        {
            gecisPaneli.SetActive(true);
        }

        // Geçiþ animasyonunun/panelinin izlenebilmesi için arka planda 0.8 saniye bekliyoruz.;
        yield return new WaitForSeconds(.8f);

        string sahneAdi = SceneManager.GetActiveScene().name;

        // Mevcut sahne ismine bakarak oyuncuyu bir sonraki zorluk seviyesine yönlendiriyor, son bölümde isek oyunu bitirme ekranýný çaðýrýyoruz.
        if (sahneAdi == "Level_1")
        {
            SceneManager.LoadScene("Level_2");
        }
        else if (sahneAdi == "Level_2")
        {
            SceneManager.LoadScene("Level_3");
        }
        else if (sahneAdi == "Level_3")
        {
           
            if (UIManager.instance != null)
            {
                UIManager.instance.FinishPanel();
            }
        }
    }
}