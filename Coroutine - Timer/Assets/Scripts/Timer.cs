using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(UserInputReceiver))]
public class Timer : MonoBehaviour
{
    private readonly float _delay = 0.5f;

    private UserInputReceiver _receiver;
    private Coroutine _coroutine;
    private int _currentValue;
   
    public event Action<int> ValueChanged;

    private void Awake()
    {
        _receiver = GetComponent<UserInputReceiver>();
    }

    private void OnEnable()
    {
        _receiver.MouseButtonPressed += OnMouseButtonPressed;
    }

    private void OnDisable()
    {
        _receiver.MouseButtonPressed -= OnMouseButtonPressed;
    }

    private void OnMouseButtonPressed()
    {
        if (_coroutine != null) 
        {
            StopCoroutine(_coroutine);

            _coroutine = null;

            return;
        }

        _coroutine = StartCoroutine(CountUp(_delay));
    }

    private IEnumerator CountUp(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            ValueChanged?.Invoke(_currentValue++);

            yield return wait;
        }
    }
}
