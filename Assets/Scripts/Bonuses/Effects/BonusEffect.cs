using System.Collections;
using UnityEngine;

public abstract class BonusEffect : MonoBehaviour
{
    protected float _duration = 1.0f;
    protected abstract void StartEffect(); 
    protected abstract void UpdateEffect(); 
    protected abstract void EndEffect();

    private bool _started = false;
    private void Start()
    {
        StartCoroutine(ProcessEffect());
    }

    private void Update()
    {
        if(_started)
        {
            UpdateEffect();
        }
    }
    private IEnumerator ProcessEffect()
    {
        _started = true;
       
        StartEffect();
        yield return new WaitForSeconds(_duration);
        _started = false;
        EndEffect();
        Destroy(this);
    }
}
