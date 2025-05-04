using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine.VFX;

public class CoolTime : MonoBehaviour
{
    public Animator ani;
    [SerializeField]
    private SkillSystem skillSystem;
    public Color cooldownColor = new Color(1, 1, 1, 0.7f);

    private Dictionary<KeyCode, SkillCooldown> cooldownDict = new Dictionary<KeyCode, SkillCooldown>();
     
    private Dictionary<KeyCode, bool> isCooldownActive = new Dictionary<KeyCode, bool>();

    void Awake()
    {
        skillSystem = FindAnyObjectByType<SkillSystem>();
    }

    private void Start()
    {
        foreach (var skill in skillSystem.skillCooldowns)
        {
            cooldownDict[skill.key] = skill;
            isCooldownActive[skill.key] = false; // 모든 키의 쿨다운 상태 초기화
            ResetCooldownUI(skill);
        }
    }

    protected virtual void Update()
    {   
        foreach (var skill in skillSystem.skillCooldowns)
        {
            if (Input.GetKeyDown(skill.key) && !isCooldownActive[skill.key] && !GameManager.Instance.isSkillPlaying)
            {
                UseSkill(skill);
                StartCoroutine(CooldownEffect(skill , skill.cooldownTime));
            }
        }
    }

    protected virtual void UseSkill(SkillCooldown skill)
    {
        // 자식 클래스에서 오버라이드해서 사용
    }

    private IEnumerator CooldownEffect(SkillCooldown skill , float cooldown)
    {
        skill.text.gameObject.SetActive(false);
        float elapsedTime = 0f;
        Color overlayColor = cooldownColor;
        Vector2 originalSize = skill.cooldownOverlay.rectTransform.sizeDelta;

        skill.cooldownOverlay.color = overlayColor;
        isCooldownActive[skill.key] = true;

        while (elapsedTime < cooldown)
        {
            elapsedTime += Time.deltaTime;
            float remainingTime = cooldown - elapsedTime;
            skill.cooldownText.text = Mathf.CeilToInt(remainingTime).ToString();

            // 아래에서 위로 사라지는 효과
            float heightRatio = remainingTime / cooldown;
            skill.cooldownOverlay.rectTransform.sizeDelta = new Vector2(originalSize.x, originalSize.y * heightRatio);

            // 투명도 조절
            overlayColor.a = heightRatio;
            skill.cooldownOverlay.color = overlayColor;

            yield return null;
        }
        skill.cooldownText.text = "";
        skill.cooldownOverlay.color = new Color(1, 1, 1, 0); // 완전히 투명
        skill.cooldownOverlay.rectTransform.sizeDelta = originalSize; // 크기 초기화
        skill.text.gameObject.SetActive(true);
        isCooldownActive[skill.key] = false;
    }

    private void ResetCooldownUI(SkillCooldown skill)
    {
        skill.cooldownText.text = "";
        skill.cooldownOverlay.color = new Color(1, 1, 1, 0); // 완전히 투명
        skill.cooldownOverlay.rectTransform.sizeDelta = skill.cooldownOverlay.rectTransform.sizeDelta; // 크기 초기화
        skill.text.gameObject.SetActive(true);
    }
}
