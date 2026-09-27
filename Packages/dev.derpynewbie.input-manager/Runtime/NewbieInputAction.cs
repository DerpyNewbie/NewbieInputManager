using UdonSharp;
using UnityEngine;
namespace DerpyNewbie.InputMan
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class NewbieInputAction : UdonSharpBehaviour
    {
        [SerializeField]
        private string actionName;

        public NewbieInputProvider inputProvider;

        public float pressThreshold = 0.8f;
        public float releaseThreshold = 0.2f;
        public bool isInverted;

        private float _currentValue;
        private int _currentFrame;
        private bool _wasPressed;
        private bool _isPressed;

        public bool IsPressed()
        {
            return _currentValue > pressThreshold;
        }

        public bool WasPressedThisFrame()
        {
            return _isPressed && !_wasPressed;
        }

        public bool WasReleasedThisFrame()
        {
            return !_isPressed && _wasPressed;
        }

        public float ReadValue()
        {
            if (_currentFrame != Time.frameCount)
            {
                _currentFrame = Time.frameCount;
                _currentValue = DoReadValue();

                _wasPressed = _isPressed;
                if (_isPressed)
                {
                    _isPressed = _currentValue > releaseThreshold;
                }
                else
                {
                    _isPressed = _currentValue > pressThreshold;
                }
            }

            return _currentValue;
        }

        private float DoReadValue()
        {
            if (inputProvider == null)
            {
                return 0;
            }

            if (isInverted)
            {
                return inputProvider.ReadValue() * -1;
            }

            return inputProvider.ReadValue();
        }
    }
}
