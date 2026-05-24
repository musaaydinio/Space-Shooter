using UnityEngine;

public class BackgroundReply : MonoBehaviour
{
    public float recurringValue;
    void Update()
    {
        if(transform.position.y < -recurringValue)
        {
            Recurring();
        }
    }
    public void Recurring()
    {
        Vector2 pos = new Vector2(0, recurringValue * 2);
        transform.position = (Vector2)transform.position +pos;      
    }
}
