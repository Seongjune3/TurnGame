using UnityEngine;

public class PaladinWalkSwitch : MonoBehaviour
{
    public PaladinWalk paladinWalk;
    public PaladinNomalWalk paladinNomalWalk;

    public bool isActionMode = false;


    public void ApplyMode()
    {
        if (isActionMode)
        {
            paladinNomalWalk.enabled = false;
            paladinWalk.enabled = true;
        }
        else
        {
            paladinNomalWalk.enabled = true;
            paladinWalk.enabled = false;
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
