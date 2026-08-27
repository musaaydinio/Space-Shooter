using UnityEngine;
using UnityEngine.UI;

// Oyuncunun can deðerlerini, arayüzdeki (UI) saðlýk barý güncellemelerini ve caný sýfýrlandýðýnda yaþanacak oyun bitiþ senaryosunu yönetiyoruz.
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxsaglýk = 100;
    private int gecerlisaglýk;
    [SerializeField] Image heathfill;

    // Diðer scriptlerden (örneðin düþmanlardan) oyuncunun canýna kolayca eriþebilmek için temel bir Singleton mimarisi kuruyoruz.
    public static PlayerHealth instance;

    private void Awake()
    {
        instance = this;
        
    }
    private void Start()
    {
        // Oyun baþladýðýnda mevcut caný tam kapasiteye eþitliyor ve UI barýný ilk duruma göre güncelliyoruz.
        gecerlisaglýk = maxsaglýk;
        HealthBarUpdate();
    }
    public void HasarAL(int hasarmýktarý)
    {           
        gecerlisaglýk -= hasarmýktarý;
        // Alýnan hasar sonrasý canýn eksi deðerlere düþmesini engelleyip her zaman 0 ile maksimum can arasýnda kalmasýný saðlýyoruz
        gecerlisaglýk = Mathf.Clamp(gecerlisaglýk,0,maxsaglýk);
        HealthBarUpdate();

        // Can sýfýra ulaþtýðýnda UIManager üzerinden Game Over (Oyun Bitti) panelini çaðýrýyor ve oyuncu objesini sahneden kaldýrýyoruz.
        if (gecerlisaglýk <= 0)
        {          
           UIManager.instance.GameOverPanel();
           gameObject.SetActive(false);
        }
    }
    void HealthBarUpdate()
    {
        // Mevcut caný 0 ile 1 arasýnda float bir deðere dönüþtürerek,
        // arayüzdeki Image (bar) bileþeninin doluluk oranýný (fillAmount) matematiksel olarak güncelliyoruz.
        float canmiktarý = (float)gecerlisaglýk / maxsaglýk;
        heathfill.fillAmount = canmiktarý;
    }

}
