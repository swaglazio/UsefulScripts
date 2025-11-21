using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImageController : MonoBehaviour
{
    private float _duration = 1f;
    private float _startAlpha = 0.5f;
    private SpriteRenderer _sr;
    private float _timer = 0f;
    public float Duration { get => _duration; set => _duration = value; }
    public float StartAlpha { get => _startAlpha; set => _startAlpha = value; }

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, Mathf.Lerp(StartAlpha, 0f, _timer/_duration));

        if (_sr.color.a <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
