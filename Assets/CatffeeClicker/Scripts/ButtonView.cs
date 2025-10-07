using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonView : MonoBehaviour
{
    private Button _button;
    public event Action OnClick;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {   
        _button.onClick.AddListener(() => OnClick?.Invoke());
    }

    private void OnDestroy()
    {
        if (_button != null)
            _button.onClick.RemoveAllListeners();
    }
}
