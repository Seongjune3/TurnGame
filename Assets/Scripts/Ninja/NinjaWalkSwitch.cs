using UnityEngine;

public class NinjaWalkSwitch : MonoBehaviour
{
    public NinjaWalk ninjaWalk;
    public NinjaNomalWalk ninjaNomalWalk;

    public bool isActionMode = false;



    public void ApplyMode()
    {
        if (isActionMode)
        {
            ninjaNomalWalk.enabled = false;
            ninjaWalk.enabled = true;
        }
        else
        {
            ninjaNomalWalk.enabled = true;
            ninjaWalk.enabled = false;
        }
    }

    void Update()
    {
        if (GameManager.Instance.PlayerHp <= 0)
        {
            this.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            isActionMode = !isActionMode;
            ApplyMode();
        }
    }
}
