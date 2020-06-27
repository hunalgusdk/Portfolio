using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections.Generic;

public class EffectPoolScene : MonoBehaviour
{
    [SerializeField]
    GameObject _particle;

    [SerializeField]
    int _defaultPoolSize;

    List<Effect> _pool = new List<Effect>();

    void Awake()
    {
        for (int i = 0; i < _defaultPoolSize; i++)
        {
            Create();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pickingPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            for (int i = 0; i < _pool.Count; i++)
            {
                Effect target = _pool[i];

                if (!target.isActive)
                {
                    target.Show(pickingPosition);
                    return;
                }
            }

            Effect effect = Create();

            if (effect != null)
            {
                effect.Show(pickingPosition);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }

    Effect Create()
    {
        GameObject obj = Instantiate(_particle, transform);

        if (obj != null)
        {
            Effect effect = obj.GetComponent<Effect>();

            if (effect != null)
            {
                _pool.Add(effect);

                return effect;
            }
        }

        return null;
    }
}