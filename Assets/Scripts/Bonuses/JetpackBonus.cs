using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackBonus : Bonus
{
    protected override void ApplyBonus(GameObject receiver)
    {
        if (receiver != null)
        {
            receiver.AddComponent<JetpackBonusEffect>();
        }
    }
}
