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
        if (Input.GetKeyDown(KeyCode.H))
        {
            isActionMode = !isActionMode;
            ApplyMode();
        }
    }
}
