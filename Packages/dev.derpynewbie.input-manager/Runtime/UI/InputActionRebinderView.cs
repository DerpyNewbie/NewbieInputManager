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

        private const string LogPrefix = "[InputActionRebinderView]";

        private void Update()
        {
            if (_rebindingState != RebindingState.WaitingForInput)
            {
                return;
            }

            _inputWaitingTimer += Time.deltaTime;
            if (_inputWaitingTimer < inputWaitingTime)
            {
                return;
            }

            var detected = FindActiveInputProvider();
            if (detected == null)
            {
                return;
            }

            _nextBinding = detected;
            _rebindingState = RebindingState.Confirming;

            if (nextBindingView)
            {
                nextBindingView.InputProvider = _nextBinding;
            }
        }

        /// <summary>
        /// Find the highest priority input provider whose value exceeds the detection threshold
        /// </summary>
        /// <returns>The detected provider, or null if none of the providers are active</returns>
        private NewbieInputProvider FindActiveInputProvider()
        {
            NewbieInputProvider result = null;
            foreach (var inputProvider in inputManager.InputProviders)
            {
                if (inputProvider == null || inputDetectionThreshold > inputProvider.ReadValue())
                {
                    continue;
                }

                if (result != null && result.GetPriority() > inputProvider.GetPriority())
                {
                    continue;
                }

                result = inputProvider;
            }

            return result;
        }

        public bool BeginRebinding(NewbieInputAction action)
        {
            if (_targetInputAction != null || _rebindingState != RebindingState.None)
            {
                Debug.LogWarning($"{LogPrefix} Already rebinding an input action");
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
                Debug.LogWarning($"{LogPrefix} Not confirming a rebind");
                return;
            }

            if (_targetInputAction == null)
            {
                Debug.LogWarning($"{LogPrefix} No target input action to confirm");
                return;
            }

            EndRebinding(_nextBinding);
        }

        public void CancelBinding()
        {
            if (_rebindingState == RebindingState.None)
            {
                Debug.LogWarning($"{LogPrefix} Not rebinding");
                return;
            }

            if (_targetInputAction == null)
            {
                Debug.LogWarning($"{LogPrefix} No target input action to cancel");
                return;
            }

            EndRebinding(_lastBinding);
        }

        private void EndRebinding(NewbieInputProvider binding)
        {
            _targetInputAction.binding = binding;

            _targetInputAction = null;
            _nextBinding = null;
            _lastBinding = null;
            _rebindingState = RebindingState.None;
            _inputWaitingTimer = 0f;

            gameObject.SetActive(false);
        }
    }
}
