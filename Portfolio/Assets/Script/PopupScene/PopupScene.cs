using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupScene : MonoBehaviour
{
    [SerializeField]
    Button _btnCreatePopup;

    Stack<Popup> _stack = new Stack<Popup>();  
    void Awake()
    {
        _btnCreatePopup.onClick.AddListener(OnClickCreatePopup);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_stack.Count > 0)
            {
                Popup popup = _stack.Pop();

                if (popup != null)
                {
                    popup.Close();
                }
            }
        }
    }

    void OnClickCreatePopup()
    {
        Object obj = Resources.Load("PopupScene/Popup/Popup");

        if (obj != null)
        {
            GameObject clone = Instantiate(obj, transform) as GameObject;
            Popup popup = clone.GetComponent<Popup>();

            if (popup != null)
            {
                _stack.Push(popup);
                popup.Init(_stack.Count, OnClickCreatePopup);
            }
        }
    }
}