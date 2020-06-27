using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    bool _isActive;
    public bool isActive { get { return _isActive; } }

    private void OnEnable()
    {
        _isActive = true;
    }

    private void OnDisable()
    {
        _isActive = false;
    }

    public void Show(Vector3 pickingPosition)
    {
        transform.position = pickingPosition;
        gameObject.SetActive(true);
    }
}