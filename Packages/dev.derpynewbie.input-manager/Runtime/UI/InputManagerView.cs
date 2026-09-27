using DerpyNewbie.Common;
using UdonSharp;
using UnityEngine;
namespace DerpyNewbie.InputMan.UI
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class InputManagerView : UdonSharpBehaviour
    {
        [SerializeField] [NewbieInject]
        private NewbieInputManager inputManager;

        [SerializeField]
        private GameObject inputProviderViewPrefab;

        [SerializeField]
        private Transform inputProviderViewParent;

        private void Start()
        {
            var inputProviders = inputManager.InputProviders;
            foreach (var inputProvider in inputProviders)
            {
                var providerViewGo = Instantiate(inputProviderViewPrefab, inputProviderViewParent);
                var providerView = providerViewGo.GetComponent<InputProviderView>();
                providerView.InputProvider = inputProvider;
            }
        }
    }
}
