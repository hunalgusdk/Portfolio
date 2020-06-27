using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;
using System.Collections.Generic;

public class AnimationScene : MonoBehaviour
{
    [SerializeField]
    Animator _animator;

    [SerializeField]
    float _width;

    [SerializeField]
    float _height;

    [SerializeField]
    float _interval;

    List<string> _animationList;

    void Awake()
    {
        _animationList = new List<string>();

        AnimationClip[] clip = _animator.runtimeAnimatorController.animationClips;

        for (int i = 0; i < clip.Length; ++i)
        {
            _animationList.Add(clip[i].name);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }

    void OnGUI()
    {
        int row = Screen.height / ((int)_height + (int)_interval);

        for (int i = 0; i < _animationList.Count; ++i)
        {
            float width = (i / row) * _width + (((i / row) + 1) * _interval);
            float height = (i * _height) + (_interval * (i + 1)) - ((i / row) * ((_height + _interval) * row));

            if (GUI.Button(new Rect(width, height, _width, _height), _animationList[i]))
            {
                _animator.CrossFadeInFixedTime(_animationList[i], 0.2f);
            }
        }
    }
}