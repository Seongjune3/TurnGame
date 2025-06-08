using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    public static int HealItem;
    public static int Wepon;
    public static bool UseingSmall;
    public static bool UseingMiddle;
    public static bool UseingBig;

    void Start()
    {
        Wepon = 0;
    }
    
    
    void Update()
    {
        //UseItem();
    }

    void UseItem()
    {/*
        if (Input.GetKeyDown(KeyCode.Alpha1) && HealItem == 1 && SmallItemCount >= 1 && !UseingSmall)
        {
            GameManager.Instance.PlayerHp += 50;
            SmallItemCount -= 1;
            UseingSmall = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && HealItem == 2 && MiddleItemCount >= 1 && !UseingMiddle)
        {
            GameManager.Instance.PlayerHp += 100;
            MiddleItemCount -= 1;
            UseingMiddle = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && HealItem == 3 && BigItemCount >= 1 && !UseingBig)
        {
            GameManager.Instance.PlayerHp += 150;
            BigItemCount -= 1;
            UseingBig = true;
        }*/
    }
}
