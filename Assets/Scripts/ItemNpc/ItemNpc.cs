using UnityEngine;

public class ItemNpc : MonoBehaviour
{
    public GameObject ItemMenu;
    public GameObject BuyedImageFirst;
    public GameObject BuyedImageSecond;
    public GameObject BuyedImageThird;
    public GameObject PotionImage;
    public GameObject SmallPotionImage;
    public GameObject MiddlePotionImage;
    public GameObject BigPotionImage;


    bool BuyedSmall = false;
    bool BuyedMiddle = false;
    bool BuyedBig = false;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ItemMenu.SetActive(true);    
        }
    }
    
    void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ItemMenu.SetActive(false);
        }
    }

    public void BuySmallPotion()
    {
        if (GameManager.Instance.PlayerMoney >= 50 && !BuyedSmall)
        {
        PlayerItem.HealItem = 1;
        GameManager.Instance.PlayerMoney -= 50;
        BuyedSmall = true;
        BuyedImageFirst.SetActive(true);
        PotionImage.SetActive(false);
        SmallPotionImage.SetActive(true);
        }
    }

    public void BuyMiddlePotion()
    {
        if (GameManager.Instance.PlayerMoney >= 100 && !BuyedMiddle)
        {
            PlayerItem.HealItem = 2;
            GameManager.Instance.PlayerMoney -= 100;
            BuyedMiddle = true;
            BuyedImageSecond.SetActive(true);
            PotionImage.SetActive(false);
            MiddlePotionImage.SetActive(true);
        }
    }

    public void BuyBigPotion()
    {
        if (GameManager.Instance.PlayerMoney >= 150 && !BuyedBig)
        {
            PlayerItem.HealItem = 3;
            GameManager.Instance.PlayerMoney -= 150;
            BuyedBig = true;
            BuyedImageThird.SetActive(true);
            PotionImage.SetActive(false);
            BigPotionImage.SetActive(true);
        }
    }
}
