using UnityEngine;

public class PaladinWalkSwitch : MonoBehaviour
{
    public PaladinWalk paladinWalk;
    public PaladinNomalWalk paladinNomalWalk;

    private bool isActionMode = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) // H 키를 누르면 전환
        {
            isActionMode = !isActionMode; // isActionMode의 값을 반대로 바꾸는 것 true -> false , false -> true

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
    }
}
