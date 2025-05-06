using UnityEngine;

public class Slash : MonoBehaviour
{
    bool isHited = false;

    void Start()
    {
        isHited = false;
        Destroy(gameObject , 5f);
    }


    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 15, Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isHited)
        {
            if (other.CompareTag("Boss"))
            {
                isHited = true;
                Debug.Log("보스");
                GameManager.Instance.FirstBossHp -= 100;
            }
            if (other.CompareTag("Dummy"))
            {
                isHited = true;
                Debug.Log("더미");
            }
        }
    }
}
