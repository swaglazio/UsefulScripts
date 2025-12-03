using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImageGenerator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _targetSpriteRenderer; //The sprite to be replicated
    [SerializeField] private AfterImageController _afterImagePrefab; //A game object with the Script AfterImageController and a sprite renderer
    [SerializeField] private float _interval = 0.2f; //The interval between each after image
    [SerializeField] private float _alpha = 0.5f; //The alpha of the after image (low value = more transparent)
    [SerializeField] private float _duration = 1f; //The duration of an after image

    private float _timer;

    private void OnEnable()
    {
        SpawnAfterImage();
        _timer = 0f;
    }

    private void Update()
    {
        if (_targetSpriteRenderer == null || _afterImagePrefab == null)
            return;

        _timer += Time.deltaTime;
        if (_timer >= _interval)
        {
            SpawnAfterImage();
            _timer = 0f;
        }
    }

    private void SpawnAfterImage()
    {
        AfterImageController afterImage = Instantiate(_afterImagePrefab, _targetSpriteRenderer.transform.position, _targetSpriteRenderer.transform.rotation);
        afterImage.gameObject.transform.localScale = _targetSpriteRenderer.gameObject.transform.localScale;
        afterImage.Duration = _duration;
        afterImage.StartAlpha = _alpha;

        SpriteRenderer sr = afterImage.gameObject.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sprite = _targetSpriteRenderer.sprite;
            sr.flipX = _targetSpriteRenderer.flipX;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, _alpha);
            sr.sortingOrder = _targetSpriteRenderer.sortingOrder - 1;
        }
    }
}

