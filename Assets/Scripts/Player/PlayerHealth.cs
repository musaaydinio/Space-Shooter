using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxsaglýk = 100;
    private int gecerlisaglýk;
    [SerializeField] Image heathfill;

    public static PlayerHealth instance;


    private void Awake()
    {
        instance = this;
        
    }
    private void Start()
    {
        gecerlisaglýk = maxsaglýk;
        HealthBarUpdate();
    }
    public void HasarAL(int hasarmýktarý)
    {
        gecerlisaglýk -= hasarmýktarý;
        gecerlisaglýk =Mathf.Clamp(gecerlisaglýk,0,maxsaglýk);
        HealthBarUpdate();
        if(gecerlisaglýk <= 0)
        {
            
           UIManager.instance.GameOverPanel();
           gameObject.SetActive(false);
        }
    }
    void HealthBarUpdate()
    {
        float canmiktarý = (float)gecerlisaglýk / maxsaglýk;
        heathfill.fillAmount = canmiktarý;
    }

}
