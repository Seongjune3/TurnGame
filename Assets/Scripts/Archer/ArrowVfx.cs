using UnityEngine;
using UnityEngine.VFX;

public class ArrowVfx : MonoBehaviour
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
