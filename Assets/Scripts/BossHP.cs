using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    public Image fillImage;
    public float maxHealth = 1500;
    public float currentHealth = 1500f;

    private float fullWidth;



    void Start()
    {
        fullWidth = fillImage.rectTransform.sizeDelta.x;
    }

    void UpdateHealthBar()
    {
        float ratio = Mathf.Clamp01(currentHealth / maxHealth);
        fillImage.rectTransform.sizeDelta = new Vector2(fullWidth * ratio, fillImage.rectTransform.sizeDelta.y);
    }


    void Update()
    {
        currentHealth = GameManager.Instance.FirstBossHp;
        UpdateHealthBar();
    }
}
