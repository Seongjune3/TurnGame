using UnityEngine;

public struct Data
{
    public int plusDmg;
    public string myWepon;
    public bool WeponBuff;
}

public abstract class PlayerWepon : MonoBehaviour
{
    public Data data;

    public abstract void Setting();

    public virtual void Using(GameObject SurikenImage , GameObject ShieldImage , GameObject BowImage , GameObject WhiteImage)
    {
        if (PlayerItem.Wepon == 1 && !data.WeponBuff)
        {
            data.plusDmg += 50;
            data.WeponBuff = true;
            ShieldImage.SetActive(true);
            WhiteImage.SetActive(false);
        }
        if (PlayerItem.Wepon == 2 && !data.WeponBuff)
        {
            data.plusDmg += 50;
            data.WeponBuff = true;
            BowImage.SetActive(true);
            WhiteImage.SetActive(false);
        }
        if (PlayerItem.Wepon == 3 && !data.WeponBuff)
        {
            data.plusDmg += 50;
            data.WeponBuff = true;
            SurikenImage.SetActive(true);
            WhiteImage.SetActive(false);
        }
        else
        {
            data.plusDmg += 0;
        }
    }
}
