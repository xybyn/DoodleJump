using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    // returns -1, 0, 1
    float GetHorizontalRaw();
    // returns value from -1 to 1
    float GetHorizontal();
}
