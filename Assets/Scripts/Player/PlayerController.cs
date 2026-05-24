using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("PlayerMoment")]
    [SerializeField] float moveSpeeds = 5f;
    [SerializeField] float minX = -2f;
    [SerializeField] float maxX = 2f;
    [SerializeField] float minY = -4f;
    [SerializeField] float maxY = 2f;

    [Header("BulletController")]
    [SerializeField] GameObject bulletObje;
    [SerializeField] Transform bulletSpawn;

    private void Update()
    {
        if(Time.timeScale==0)return;
        HareketPos();
        if (Input.GetMouseButtonDown(0))
        {
            BulletCont();
        }    
        
     }

    private void HareketPos()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 hareketvektoru = new Vector3(h, v, 0);
        hareketvektoru = hareketvektoru.normalized;

        Vector3 clamPos = transform.position;
        clamPos.x = Mathf.Clamp(clamPos.x, minX, maxX);
        clamPos.y = Mathf.Clamp(clamPos.y, minY, maxY);

        transform.position = clamPos;

        transform.Translate(hareketvektoru * moveSpeeds * Time.deltaTime);
    }
    
    private void BulletCont()
    {
        Instantiate(bulletObje, bulletSpawn.position, Quaternion.identity);
    }
}

