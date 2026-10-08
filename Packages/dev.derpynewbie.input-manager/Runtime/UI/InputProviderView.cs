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
        [SerializeField] [Tooltip("Moves this view to the top of its parent while the input value exceeds this threshold")]
        private float activeThreshold = 0.8f;

        public NewbieInputProvider InputProvider
        {
            get => inputProvider;
            set
            {
                inputProvider = value;

                if (text)
                {
                    text.text = value != null ? value.GetDisplayName() : "None";
                }
            }
        }

        private void Update()
        {
            var value = inputProvider != null ? inputProvider.ReadValue() : 0f;

            if (slider)
            {
                slider.value = value;
            }

            if (activeThreshold < value)
            {
                transform.SetSiblingIndex(0);
            }
        }
    }
}
