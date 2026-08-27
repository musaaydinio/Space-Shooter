
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; 

public class GameManager : MonoBehaviour
{
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
        GameObject[] dusmanlardizi = GameObject.FindGameObjectsWithTag("Enemy");
        düsmanlar = new List<GameObject>(dusmanlardizi);
    }

    public void DusmanýYokEt(GameObject obj)
    {
        if (düsmanlar.Contains(obj))
        {
            düsmanlar.Remove(obj);
        }

       
        if (düsmanlar.Count == 0)
        {
            StartCoroutine(SahneGecisSureci());
        }
    }


    IEnumerator SahneGecisSureci()
    {
        
        if (gecisPaneli != null)
        {
            gecisPaneli.SetActive(true);
        }

       
        yield return new WaitForSeconds(.8f);

        string sahneAdi = SceneManager.GetActiveScene().name;

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