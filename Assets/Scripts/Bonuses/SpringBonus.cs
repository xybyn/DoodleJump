using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBonus : Bonus
{
    protected override void ApplyBonus(GameObject receiver)
    {
        if(receiver != null)
        {
            receiver.AddComponent<SpringBonusEffect>();
        }
    }
}
