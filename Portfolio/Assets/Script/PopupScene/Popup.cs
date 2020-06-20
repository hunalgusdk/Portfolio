using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField]
    Image _imgBackground;

    [SerializeField]
    Text _txtNumber;

    [SerializeField]
    Animator _animator;

    [SerializeField]
    Button _btnCreatePopup;

    Action _callback;

    void Awake()
    {
        _btnCreatePopup.onClick.AddListener(OnClickCreatePopup);
    }

    void OnClickCreatePopup()
    {
        _callback.Invoke();
    }

    public void Init(int number, Action callback)
    {
        _imgBackground.color = new Color(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f));

        _txtNumber.text = string.Format("Popup Number : {0}", number.ToString());

        _callback = callback;
    }

    public void Close()
    {
        _animator.Play("CLOSE");
    }

    public void OnTrigger()
    {
        Destroy(gameObject);
    }
}