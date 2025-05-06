using UnityEngine;

public class NinjaWalkSwitch : MonoBehaviour
{
    public NinjaWalk ninjaWalk;
    public NinjaNomalWalk ninjaNomalWalk;

    private bool isActionMode = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) // H 키를 누르면 전환
        {
            isActionMode = !isActionMode; // isActionMode의 값을 반대로 바꾸는 것 true -> false , false -> true

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
    }
}
