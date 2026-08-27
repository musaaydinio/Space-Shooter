using UnityEngine;
using UnityEngine.SceneManagement;

// Oyunun giriþ arayüzündeki kullanýcý etkileþimlerini, sahne yüklemelerini ve oyundan çýkýþ iþlemlerini yönetiyoruz.
public class AnaMenu : MonoBehaviour
{
    public void OyunaBasla()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void OyundanÇýk()
    {
        Application.Quit();
    }
}
