using UnityEngine;

//Oyun içindeki anlýk ses efektlerini buton týklamalarý, patlamalar, kazanma durumu her sahneden
//ve scriptten kolayca çaðýrabilmek için merkezi bir ses yöneticisi kuruyoruz.
public class SoundManager : MonoBehaviour
{
    // Diðer sýnýflarýn bu scripte referanssýz ulaþabilmesi için Singleton tasarým desenini uyguluyoruz.
    public static SoundManager instance;

    [SerializeField]  AudioSource mouseclik;
    [SerializeField] AudioSource enemydealth;
    [SerializeField] AudioSource playerdealth;
    [SerializeField] AudioSource meteor;
    [SerializeField] AudioSource win;
    private void Awake()
    {
        instance = this;
    }
    public void MouseClick()
    {
        mouseclik.Play();
    }
    public void EnmeySound()
    {
        enemydealth.Play();
    }
    public void PlayerSound()
    {
        playerdealth.Play();
    }
    public void MeteroSound()
    {
        meteor.Play();
    }
    public void WinSound()
    {
        win.Play();
    }
}
