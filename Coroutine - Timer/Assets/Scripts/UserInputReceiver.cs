using System;
using UnityEngine;

public class UserInputReceiver : MonoBehaviour
{
    public event Action MouseButtonPressed;

    private void Update()
    {
        var userInput = Input.GetMouseButtonDown(0);

        if (userInput)
            MouseButtonPressed?.Invoke();
    }
}
