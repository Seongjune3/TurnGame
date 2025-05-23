using UnityEngine;
using System.Collections;
using UnityEngine.VFX;

public class NinjaCSkill : CoolTime
{
    [SerializeField]
    public bool isUseSkill = false;
    bool isCoolTime = false;
    public bool isHited = false;
    public GameObject player;
    public VisualEffect smokeVFX;
    public GameObject objectToSpawn;
    public float spawnDistance = 2f;
    public GameObject hitBox;

    protected override void UseSkill(SkillCooldown skill)
    {
        if (skill.key == KeyCode.C && !isCoolTime && !GameManager.Instance.isSkillPlaying)
        {
            GameManager.Instance.isSkillPlaying = true;
            StartCoroutine(SkillCoolDown());
            StartCoroutine(ChangeBool());
            StartCoroutine(SkillMove());
        }
    }

    IEnumerator SkillCoolDown()
    {
        isCoolTime = true;
        yield return new WaitForSeconds(30f);
        isCoolTime = false;
    }

    IEnumerator ChangeBool()
    {
        isUseSkill = true;
        yield return new WaitForSeconds(2.5f);
        GameManager.Instance.isSkillPlaying = false;
        isUseSkill = false;
        isHited = false;
    }

    IEnumerator SkillMove()
    {
        player.tag = "Invisible";
        smokeVFX.Play();
        yield return new WaitForSeconds(1f);
        hitBox.SetActive(true);
        player.tag = "Player";
        SpawnBlackNinja();
        ani.Play("Knife Shot");
        yield return new WaitForSeconds(0.5f);
        hitBox.SetActive(false);
    }

    void SpawnBlackNinja()
    {
        // 왼쪽 대각선 (전방 + 좌측)
        Vector3 leftDiagonal = player.transform.forward + -player.transform.right;
        Vector3 leftSpawnPos = player.transform.position + leftDiagonal.normalized * spawnDistance;
        GameObject leftObject = Instantiate(objectToSpawn, leftSpawnPos, Quaternion.identity);
        leftObject.transform.LookAt(transform);

        Vector3 eulerRotation = leftObject.transform.rotation.eulerAngles;
        eulerRotation.x = 0;  // X축 회전 0으로 설정
        leftObject.transform.rotation = Quaternion.Euler(eulerRotation);

        // 오른쪽 대각선 (전방 + 우측)
        Vector3 rightDiagonal = player.transform.forward + player.transform.right;
        Vector3 rightSpawnPos = player.transform.position + rightDiagonal.normalized * spawnDistance;
        GameObject rightObject = Instantiate(objectToSpawn, rightSpawnPos, Quaternion.identity);
        rightObject.transform.LookAt(transform);

        eulerRotation = rightObject.transform.rotation.eulerAngles;
        eulerRotation.x = 0;  // X축 회전 0으로 설정
        rightObject.transform.rotation = Quaternion.Euler(eulerRotation);
    }
}
