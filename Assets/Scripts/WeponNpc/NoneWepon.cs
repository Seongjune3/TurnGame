using UnityEngine;

public class NoneWepon : PlayerWepon
{
    public override void Setting()
    {
        data.plusDmg += 0;
        data.myWepon = "없음";
    }

    public override void Using(GameObject SurikenImage, GameObject ShieldImage, GameObject BowImage, GameObject WhiteImageObject)
    {
        base.Using(SurikenImage , ShieldImage , BowImage , WhiteImageObject);
    }
}
