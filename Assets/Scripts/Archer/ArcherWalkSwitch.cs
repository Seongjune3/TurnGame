using UnityEngine;

public class ArcherWalkSwitch : MonoBehaviour
{
    public ArcherWalk archerWalk;
    public ArcherNomalWalk archerNomalWalk;

    private bool isActionMode = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) // H 키를 누르면 전환
        {
            isActionMode = !isActionMode; // isActionMode의 값을 반대로 바꾸는 것 true -> false , false -> true

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
    }
}
