using UnityEngine;
using UnityEngine.VFX;

public class TrailVFX : MonoBehaviour
{
    public VisualEffect vfx;

    void Update()
    {
        vfx.SetVector3("Position", transform.position);
        vfx.SendEvent("OnSpawn"); // 그래프 내에 동일한 이름의 이벤트 사용
    }
}
