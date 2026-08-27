using UnityEngine;

// Sonsuz uzay hissini vermek için arka plan görselinin yukarýdan aþaðýya sürekli akmasýný ve ekran bitiminde tekrar baþa sarmasýný saðlýyoruz.
public class BackgroundReply : MonoBehaviour
{
    public float recurringValue;
    void Update()
    {
        // Arka plan görseli belirlediðimiz eksi Y koordinatýnýn altýna düþtüðünde,
        // yani kameranýn görüþ açýsýndan tamamen çýktýðýnda döngüyü tetikliyoruz.
        if (transform.position.y < -recurringValue)
        {
            Recurring();
        }
    }
    public void Recurring()
    {
        // Görüntüden çýkan arka plan görselini, belli etmeden anýnda kameranýn üst kýsmýna ýþýnlayarak oyuncuya kesintisiz bir uzay akýþý sunuyoruz.
        Vector2 pos = new Vector2(0, recurringValue * 2);
        transform.position = (Vector2)transform.position +pos;      
    }
}
