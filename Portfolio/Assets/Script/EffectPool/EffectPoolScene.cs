using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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