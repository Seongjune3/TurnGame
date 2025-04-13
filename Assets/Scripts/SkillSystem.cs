using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System.Collections.Generic;


public class SkillSystem : MonoBehaviour
{
    public List<SkillCooldown> skillCooldowns;  // 여러 개의 키와 이미지를 관리하는 리스트
}

[System.Serializable]
public class SkillCooldown
{
    public KeyCode key;  // 예: KeyCode.Q, KeyCode.Z, KeyCode.X, KeyCode.C
    public Image cooldownOverlay;  // 해당 키에 해당하는 쿨다운 이미지
    public TextMeshProUGUI cooldownText;  // 해당 키의 쿨다운 텍스트
    public float cooldownTime; // 각각 다른 쿨타임 적용
    public TextMeshProUGUI text; // 원래 텍스트
}