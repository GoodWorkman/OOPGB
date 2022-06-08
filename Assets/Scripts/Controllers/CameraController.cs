using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class CameraController : IExecute
    {
        private Transform _player;
        private Transform _mainCameraTransform;
        private Vector3 _offset;
        
        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCameraTransform = mainCamera;
            
            _mainCameraTransform.LookAt(_player);
            _offset = _mainCameraTransform.position - _player.position;
        }
        public void Update()
        {
            _mainCameraTransform.position = _player.position + _offset;
        }
    }
}
