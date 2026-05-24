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
        gecerlisaglýk = maxsaglýk;
        CanBarýGuncelleme();
    }

    public void AlýnanHasar(int hasarmýktarý)
    { 
        gecerlisaglýk -= hasarmýktarý;
        gecerlisaglýk = Mathf.Clamp(gecerlisaglýk, 0, maxsaglýk);
        CanBarýGuncelleme();
        if (gecerlisaglýk <= 0)
        {
            SoundManager.instance.EnmeySound();
            GameManager.instance.DusmanýYokEt(this.gameObject);
            Destroy(gameObject);
        }
    }
    void CanBarýGuncelleme()
    {
        float canmýktarý = (float)gecerlisaglýk / maxsaglýk;
        canbarý.fillAmount = canmýktarý;
        canMetni.text=gecerlisaglýk.ToString();
    }
}
