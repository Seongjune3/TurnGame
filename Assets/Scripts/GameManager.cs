using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool PlayArcher = false;
    public bool PlayPaladin = false;
    public bool PlayNinja = false;


    public bool PlayerIsJumping = false;
    public bool PlayerIsComming = false;
    

    public int FirstBossHp = 3000;
    public int SecondBossHp = 4500;
    public int PlayerHp = 500;

    public int PlayerMoney = 500;

    public bool UseingZeroSkill = false;
    public bool UseingFirstSkill = false;
    public bool UseingSecondSkill = false;
    public bool UseingThirdSkill = false;

    


    private static GameManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
