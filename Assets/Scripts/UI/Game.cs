using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    public UnityEvent OnRestartGame = new UnityEvent();

    private bool _alreadyStarted = false;
    private void OnEnable()
    {
        if (_alreadyStarted)
            Restart();
        else
            _alreadyStarted = true;
    }
    public void Restart()
    {
        OnRestartGame.Invoke();
    }
}
