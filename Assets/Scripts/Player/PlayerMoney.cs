using NUnit.Framework.Internal;
using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        
    }

    void Update()
    {
        text.text = "가진 돈: " + GameManager.Instance.PlayerMoney;
    }
}
