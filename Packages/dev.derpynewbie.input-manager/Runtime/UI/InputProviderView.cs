using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
namespace DerpyNewbie.InputMan.UI
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class InputProviderView : UdonSharpBehaviour
    {
        [SerializeField]
        private Slider slider;
        [SerializeField]
        private TMP_Text text;
        [SerializeField]
        private NewbieInputProvider inputProvider;

        public NewbieInputProvider InputProvider
        {
            get => inputProvider;
            set
            {
                inputProvider = value;
                if (text) text.text = value != null ? value.GetDisplayName() : "None";
            }
        }

        private void Update()
        {
            var value = InputProvider.ReadValue();
            slider.value = value;
            if (0.8f < value)
            {
                transform.SetSiblingIndex(0);
            }
        }
    }
}
