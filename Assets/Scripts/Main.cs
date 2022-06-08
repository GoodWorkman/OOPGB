using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private ListExecuteObject _interactiveObject;
        private InputController _inputController;
        private Reference _reference;
        private ViewBonus _viewBonus;
        private ViewEndGame _viewEndGame;
        private CameraController _cameraController;
        
        private int _bonusCount;
        
        [SerializeField] private BadBonus badBonus;
        
        [SerializeField] private GameObject player;
        [SerializeField] private Button restartButton;

        private void Awake()
        {
            Time.timeScale = 1f;
            _reference = new Reference();
            
            _inputController = new InputController(player.GetComponent<Unit>());
            _interactiveObject = new ListExecuteObject();

            _cameraController = new CameraController(player.transform, _reference.MainCamera.transform);

            _viewBonus = new ViewBonus(_reference.BonusLabel);
            _viewEndGame = new ViewEndGame(_reference.GameOver);
            restartButton.onClick.AddListener(RestartGame);
            restartButton.gameObject.SetActive(false);
            _interactiveObject.AddExecuteObject(_inputController);
            _interactiveObject.AddExecuteObject(_cameraController);

            foreach (var item in _interactiveObject)
            {
                if (item is GoodBonus goodBonus)
                {
                    goodBonus.AddScore += AddBonus;
                }
                if (item is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayer += _viewEndGame.GameOver;
                    badBonus.OnCaughtPlayer += CaughtPlayer;
                }
            }
        }

        private void CaughtPlayer(string value, Color args)
        {
            restartButton.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        private void AddBonus(int value)
        {
            _bonusCount += value;
            _viewBonus.Display(_bonusCount);
        }
        
         void Update()
        {
            for (int i = 0; i < _interactiveObject.Lenght; i++)
            {
                if (_interactiveObject[i] == null)
                {
                    continue;
                }

                _interactiveObject[i].Update();
            }
        }
    }
}

