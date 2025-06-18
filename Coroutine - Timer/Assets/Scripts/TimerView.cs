using TMPro;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Timer _timer;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
    }

    private void OnEnable()
    {
        _timer.ValueChanged += OnTimeChanged;
    }

    private void OnDisable()
    {
        _timer.ValueChanged -= OnTimeChanged;
    }

    private void OnTimeChanged(int time)
    {
        _text.text = time.ToString("");
    }
}
