using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController _player;
    public BoxCollider2D _mapBox;
    private float _halfHeight;
    private float _halfWidth;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _halfHeight = Camera.main.orthographicSize;
        _halfWidth = _halfHeight * Camera.main.aspect;
    }

    private void Update()
    {
        if (_player != null)
        {
            transform.position = new Vector3(Mathf.Clamp(_player.transform.position.x, _mapBox.bounds.min.x + _halfWidth,
                                            _mapBox.bounds.max.x - _halfWidth),
                                            Mathf.Clamp(_player.transform.position.y, _mapBox.bounds.min.y + _halfHeight,
                                            _mapBox.bounds.max.y - _halfHeight), transform.position.z);
        }
    }
}
