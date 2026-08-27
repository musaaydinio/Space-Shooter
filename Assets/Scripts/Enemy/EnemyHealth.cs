using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxsaglýk = 100;
    private int gecerlisaglýk;
    [SerializeField] Image canbarý;
    [SerializeField] TextMeshProUGUI canMetni;
   
    private void Start()
    {
        // Düþman sahneye doðduðunda canýný maksimum deðere eþitliyor ve arayüzdeki can barýný güncelliyoruz.
        gecerlisaglýk = maxsaglýk;
        CanBarýGuncelleme();
    }

    public void AlýnanHasar(int hasarmýktarý)
    { 
        gecerlisaglýk -= hasarmýktarý;

        // Eksi deðerleri engellemek için mevcut caný 0 ile maksimum can arasýnda sýnýrlandýrýyoruz.
        gecerlisaglýk = Mathf.Clamp(gecerlisaglýk, 0, maxsaglýk);
        CanBarýGuncelleme();
        // Düþmanýn caný bittiðinde patlama sesini çalýyor, skor veya dalga kontrolü için GameManager'a haber veriyor ve objeyi yok ediyoruz.
        if (gecerlisaglýk <= 0)
        {
            SoundManager.instance.EnmeySound();
            GameManager.instance.DusmanýYokEt(this.gameObject);
            Destroy(gameObject);
        }
    }
    void CanBarýGuncelleme()
    {
        // Mevcut can oranýný matematiksel olarak hesaplayýp düþmanýn üzerindeki UI bileþenlerine yansýtýyoruz.
        float canmýktarý = (float)gecerlisaglýk / maxsaglýk;
        canbarý.fillAmount = canmýktarý;
        canMetni.text=gecerlisaglýk.ToString();
    }
}
