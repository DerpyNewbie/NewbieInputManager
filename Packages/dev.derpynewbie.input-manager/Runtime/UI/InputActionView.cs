using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
namespace DerpyNewbie.InputMan.UI
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class InputActionView : UdonSharpBehaviour
    {
        [SerializeField]
        private Slider slider;
        [SerializeField]
        private Image image;
        [SerializeField]
        private TMP_Text actionNameText;
        [SerializeField]
        private TMP_Text bindingDisplayNameText;
        [SerializeField]
        private NewbieInputAction inputAction;

        [SerializeField]
        private Color normalColor = Color.gray;
        [SerializeField]
        private Color activeColor = Color.white;
        [SerializeField]
        private Color pressedColor = Color.red;
        [SerializeField]
        private Color releasedColor = Color.green;

        public NewbieInputAction InputAction
        {
            get => inputAction;
            set => inputAction = value;
        }

        private void Start()
        {
            InputAction = InputAction;
        }

        private void Update()
        {
            if (slider)
            {
                var value = InputAction.ReadValue();
                slider.value = value;
            }

            if (image)
            {
                image.color = InputAction.IsPressed() ? activeColor : normalColor;

                if (InputAction.WasPressedThisFrame())
                {
                    image.color = pressedColor;
                }

                if (InputAction.WasReleasedThisFrame())
                {
                    image.color = releasedColor;
                }
            }

            if (actionNameText)
            {
                actionNameText.text = InputAction ? InputAction.ActionName : "<NULL>";
            }

            if (bindingDisplayNameText)
            {
                bindingDisplayNameText.text = InputAction && InputAction.binding ? InputAction.binding.GetDisplayName() : "<UNBOUND>";
            }
        }
    }
}
