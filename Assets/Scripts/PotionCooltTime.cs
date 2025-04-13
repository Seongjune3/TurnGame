using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class PotionCoolTime : MonoBehaviour
{
    public Image cooldownoverlay;  // 쿨타임 오버레이 (하얀 이미지)
    public TextMeshProUGUI cooldownText;  // 쿨타임 표시 텍스트
    public float cooldownTime = 10f;  // 쿨타임 지속 시간
    public Color cooldownColor = new Color(1, 1, 1, 0.7f); // 쿨타임 시 보이는 색상 (설정 가능)

    private Vector2 originalSize;

    int SmallItemCount = 5;
    int MiddleItemCount = 5;
    int BigItemCount = 5;

    public bool UseingSmall;
    public bool UseingMiddle;
    public bool UseingBig;

    private void Start()
    {
        originalSize = cooldownoverlay.rectTransform.sizeDelta; // 원래 크기 저장
        ResetCooldownUI();
    }

    private void Update()
    {
        UsePotion();
    }

    public void UsePotion()
    {
        if (PlayerItem.HealItem == 1 && !UseingSmall && Input.GetKeyDown(KeyCode.Alpha1) && SmallItemCount >= 1)
        {
            StartCoroutine(CooldownEffect());
        }
        if (PlayerItem.HealItem == 2 && !UseingMiddle && Input.GetKeyDown(KeyCode.Alpha1) && MiddleItemCount >= 1)
        {
            StartCoroutine(CooldownEffect());
        }
        if (PlayerItem.HealItem == 3 && !UseingBig && Input.GetKeyDown(KeyCode.Alpha1) && BigItemCount >= 1)
        {
            StartCoroutine(CooldownEffect());
        }
    }

    IEnumerator CooldownEffect()
    {
        float elapsedTime = 0f;
        Color overlayColor = cooldownColor;  // 설정한 색상 사용
        Vector2 startSize = originalSize; // 원래 크기 저장

        // 쿨타임 시작 시 이미지 보이게 설정
        cooldownoverlay.color = overlayColor;

        GameManager.Instance.PlayerHp += 50;
        SmallItemCount -= 1;
        UseingSmall = true;

        while (elapsedTime < cooldownTime)
        {
            elapsedTime += Time.deltaTime;
            float remainingTime = cooldownTime - elapsedTime;
            cooldownText.text = Mathf.CeilToInt(remainingTime).ToString(); // 텍스트 업데이트

            // 아래에서 위로 사라지는 효과 (Height 줄이기)
            float heightRatio = remainingTime / cooldownTime;
            cooldownoverlay.rectTransform.sizeDelta = new Vector2(startSize.x, startSize.y * heightRatio);

            // 투명도 조절
            overlayColor.a = heightRatio;
            cooldownoverlay.color = overlayColor;

            yield return null;
        }
        ResetCooldownUI();
        UseingSmall = false;

    }
    void ResetCooldownUI()
    {
        cooldownText.text = "";
        cooldownoverlay.color = new Color(1, 1, 1, 0); // 완전히 투명하게 만들기
        cooldownoverlay.rectTransform.sizeDelta = originalSize; // 원래 크기로 복구
    }
}