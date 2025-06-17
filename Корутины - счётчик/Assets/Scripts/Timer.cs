using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private readonly float _delay = 0.5f;

    private int _currentValue = 0;
    private bool _isActive = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isActive == false)
        {
            _isActive = true;

            StartCoroutine(CountUp(_delay, _currentValue));
        }

        else if (Input.GetMouseButtonDown(0) && _isActive)
        {
            _isActive = false;

            StopCoroutine(CountUp(_delay, _currentValue));
        }
    }

    private IEnumerator CountUp(float delay, int time)
    {
        var wait = new WaitForSeconds(delay);

        while (_isActive)
        {
            time += 1;
            _currentValue = time;

            DisplayCountUp(time);

            yield return wait;
        }
    }

    private void DisplayCountUp(int time)
    {
        _text.text = time.ToString("");
    }
}
