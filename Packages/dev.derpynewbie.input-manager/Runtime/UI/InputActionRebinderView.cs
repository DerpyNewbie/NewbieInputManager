using UdonSharp;
using UnityEngine;
using VRC.Udon.Common.Interfaces;
namespace DerpyNewbie.InputMan.UI
{
    public enum RebindingState
    {
        None,
        WaitingForInput,
        Confirming,
    }

    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class InputActionRebinderView : UdonSharpBehaviour
    {
        [SerializeField]
        private NewbieInputManager inputManager;

        [SerializeField]
        private InputProviderView nextBindingView;

        [SerializeField] [Tooltip("Discard all inputs until the specified time has passed")]
        private float inputWaitingTime = 0.5f;

        [SerializeField] [Tooltip("Rebinding threshold to detect as input")]
        private float inputDetectionThreshold = 0.8f;

        private float _inputWaitingTimer;
        private NewbieInputAction _targetInputAction;
        private NewbieInputProvider _nextBinding;
        private NewbieInputProvider _lastBinding;
        private RebindingState _rebindingState;

        private void Update()
        {
            switch (_rebindingState)
            {
                case RebindingState.None:
                {
                    break;
                }
                case RebindingState.WaitingForInput:
                {
                    _inputWaitingTimer += Time.deltaTime;

                    if (_inputWaitingTimer < inputWaitingTime)
                    {
                        break;
                    }

                    foreach (var inputProvider in inputManager.InputProviders)
                    {
                        if (inputDetectionThreshold > inputProvider.ReadValue())
                        {
                            continue;
                        }

                        if (_nextBinding && _nextBinding.GetPriority() > inputProvider.GetPriority())
                        {
                            continue;
                        }

                        _nextBinding = inputProvider;
                        _rebindingState = RebindingState.Confirming;

                        if (nextBindingView)
                        {
                            nextBindingView.InputProvider = _nextBinding;
                        }
                    }
                    break;
                }
                case RebindingState.Confirming:
                {
                    break;
                }
            }
        }

        public bool BeginRebinding(NewbieInputAction action)
        {
            if (_targetInputAction != null || _rebindingState != RebindingState.None)
            {
                Debug.LogWarning("[InputActionRebinderView] Already rebinding an input action");
                return false;
            }

            _targetInputAction = action;
            _lastBinding = action.binding;
            _nextBinding = null;
            _rebindingState = RebindingState.WaitingForInput;
            _inputWaitingTimer = 0f;

            gameObject.SetActive(true);
            return true;
        }

        public void ConfirmBinding()
        {
            if (_rebindingState != RebindingState.Confirming)
            {
                Debug.LogWarning("[InputActionRebinderView] Not confirming a rebind");
                return;
            }

            if (_targetInputAction == null)
            {
                Debug.LogWarning("[InputActionRebinderView] No target input action to confirm");
                return;
            }

            _targetInputAction.binding = _nextBinding;

            _targetInputAction = null;
            _nextBinding = null;
            _lastBinding = null;
            _rebindingState = RebindingState.None;
            _inputWaitingTimer = 0f;

            gameObject.SetActive(false);
        }

        public void CancelBinding()
        {
            if (_rebindingState == RebindingState.None)
            {
                Debug.LogWarning("[InputActionRebinderView] Not rebinding");
                return;
            }

            if (_targetInputAction == null)
            {
                Debug.LogWarning("[InputActionRebinderView] No target input action to cancel");
                return;
            }

            _targetInputAction.binding = _lastBinding;

            _targetInputAction = null;
            _nextBinding = null;
            _lastBinding = null;
            _rebindingState = RebindingState.None;
            _inputWaitingTimer = 0f;

            gameObject.SetActive(false);
        }
    }
}
