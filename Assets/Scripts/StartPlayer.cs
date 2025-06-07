using Unity.Mathematics;
using UnityEngine;

public class StartPlayer : MonoBehaviour
{
    public GameObject ninja;
    public GameObject paladin;
    public GameObject archer;



    void Awake()
    {
        if (GameManager.Instance.PlayNinja)
        {
            Instantiate(ninja, new Vector3(-1.6f, 12.261f, -73.38f), quaternion.identity);
        }
        else if (GameManager.Instance.PlayPaladin)
        {
            Instantiate(paladin, new Vector3(-1.6f, 12.261f, -73.38f), quaternion.identity);
        }
        else if (GameManager.Instance.PlayArcher)
        {
            Instantiate(archer, new Vector3(-1.6f, 12.261f, -73.38f), quaternion.identity);
        }
    }
}
