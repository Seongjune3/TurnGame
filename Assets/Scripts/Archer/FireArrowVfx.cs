using UnityEngine;
using UnityEngine.VFX;

public class FireArrowVfx : MonoBehaviour
{
    VisualEffect visualEffect;

    void Start()
    {
        visualEffect = GetComponent<VisualEffect>();
    }

    void Update()
    {
        if (transform.parent == null)
        {
            visualEffect.Stop();
            Destroy(gameObject, 2f);
        }
    }
}