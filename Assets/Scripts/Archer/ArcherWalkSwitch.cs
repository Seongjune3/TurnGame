using UnityEngine;

public class ArcherWalkSwitch : MonoBehaviour
{
    public ArcherWalk archerWalk;
    public ArcherNomalWalk archerNomalWalk;

    public bool isActionMode = false;


    public void ApplyMode()
    {
        if (isActionMode)
        {
            archerNomalWalk.enabled = false;
            archerWalk.enabled = true;
        }
        else
        {
            archerNomalWalk.enabled = true;
            archerWalk.enabled = false;
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
