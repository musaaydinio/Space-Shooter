using UnityEngine;
using UnityEngine.SceneManagement;

// Oyunun UI panellerini, zamanýn durdurulmasý/baþlatýlmasý gibi oyun içi akýþ durumlarýný ve sahne geçiþlerini merkezi olarak yönetiyoruz.
public class UIManager : MonoBehaviour
{
    public GameObject pausePanel;
    bool oyunudurdur = false;
    public GameObject gameover;
    public static UIManager instance;
    public GameObject finish;


    private void Awake()
    {
        // Game Over ve Finish gibi tetikleyicilere diðer scriptlerden anýnda ulaþabilmek için Singleton yapýsýný kuruyoruz.
        instance = this;
    }

    private void Update()
    {
        // Klavyeden ESC tuþuna basýldýðýnda oyunu duraklatma/devam ettirme mekanizmasýný tetikliyoruz.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DurumDegistir();
        }
    }
    void DurumDegistir()
    {
        // Oyunun durdurulma durumunu (true/false) tersine çeviriyoruz.
        oyunudurdur = !oyunudurdur;
        if (oyunudurdur)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void PaneliAc()
    {
        // UI butonlarý üzerinden manuel olarak oyunu duraklatmak istediðimizde bu metodu kullanýyoruz.
        if (!oyunudurdur)
        {
            SoundManager.instance.MouseClick();
            DurumDegistir();
        }
    }
    public void PaneliKapat()
    {
        if (oyunudurdur)
        {
            DurumDegistir();
        }
    }
    public void GameOverPanel()
    {
        gameover.SetActive(true);
        Time.timeScale = 0f;
        SoundManager.instance.PlayerSound();
    }

    public void FinishPanel()
    {
        // Bölüm/Oyun baþarýyla tamamlandýðýnda kazanma panelini aktif ediyor ve özel kazanma müziðini çalýyoruz.
        if (finish != null)
        {
            finish.SetActive(true);
            Time.timeScale = 1f;
        }
        if (SoundManager.instance != null)
        {
            SoundManager.instance.WinSound();
        }     
    }

    public void TekrarOyna()
    {
        // Karakter öldükten veya oyun bittikten sonra tekrar oynamak için zamaný sýfýrlayýp Level_1 sahnesini yeniden yüklüyoruz.
        SoundManager.instance.MouseClick();
        SoundManager.instance.MouseClick();
        SceneManager.LoadScene("Level_1");
        Time.timeScale = 1f;        
    }

    public void AnaMenü()
    {
        // Ana menüye dön butonuna týklandýðýnda zaman döngüsünü düzeltip giriþ sahnesine geçiþ yapýyoru
        SoundManager.instance.MouseClick();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MaýnMenü");
    }
}

