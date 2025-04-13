using UnityEngine;

public class WeponController : MonoBehaviour
{
    public PlayerWepon myWepon;
    public GameObject SurikenImage;
    public GameObject ShieldImage;
    public GameObject BowImage;
    public GameObject WhiteImage;
    void Start()
    {
        myWepon.Setting();
    }

    
    void Update()
    {
        myWepon.Using(SurikenImage , ShieldImage , BowImage , WhiteImage);
    }
}
