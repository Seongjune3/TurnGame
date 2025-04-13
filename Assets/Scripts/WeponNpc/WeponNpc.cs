using UnityEngine;

public class WeponNpc : MonoBehaviour
{
    public GameObject ShieldMenu;
    public GameObject BowMenu;
    public GameObject DaggerMenu;
    public GameObject BuyedImageFirst;
    public GameObject BuyedImageSecond;
    public GameObject BuyedImageThird;
    bool BuyedShield = false;
    bool BuyedBow = false;
    bool BuyedDagger = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameManager.Instance.PlayPaladin)
        {
            ShieldMenu.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Player") && GameManager.Instance.PlayArcher)
        {
            BowMenu.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Player") && GameManager.Instance.PlayNinja)
        {
            DaggerMenu.SetActive(true);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameManager.Instance.PlayPaladin)
        {
            ShieldMenu.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Player") && GameManager.Instance.PlayArcher)
        {
            BowMenu.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Player") && GameManager.Instance.PlayNinja)
        {
            DaggerMenu.SetActive(false);
        }
    }

    public void BuyShield()
    {
        if (GameManager.Instance.PlayerMoney >= 500 && !BuyedShield)
        {
            PlayerItem.Wepon = 1;
            GameManager.Instance.PlayerMoney -= 500;
            BuyedShield = true;
            BuyedImageFirst.SetActive(true);
        }
    }

    public void BuyBow()
    {
        if (GameManager.Instance.PlayerMoney >= 500 && !BuyedBow)
        {
            PlayerItem.Wepon = 2;
            GameManager.Instance.PlayerMoney -= 500;
            BuyedBow = true;
            BuyedImageSecond.SetActive(true);
        }
    }

    public void BuyDagger()
    {
        if (GameManager.Instance.PlayerMoney >= 500 && !BuyedDagger)
        {
            PlayerItem.Wepon = 3;
            GameManager.Instance.PlayerMoney -= 500;
            BuyedDagger = true;
            BuyedImageThird.SetActive(true);
        }
    }
}
