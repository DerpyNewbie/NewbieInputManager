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

        private void Update()
        {
            if (inputAction == null)
            {
                SetText(actionNameText, "<NULL>");
                SetText(bindingDisplayNameText, "<UNBOUND>");
                return;
            }

            if (slider)
            {
                slider.value = inputAction.ReadValue();
            }

            if (image)
            {
                image.color = GetStateColor();
            }

            SetText(actionNameText, inputAction.ActionName);
            SetText(bindingDisplayNameText, inputAction.binding ? inputAction.binding.GetDisplayName() : "<UNBOUND>");
        }

        private Color GetStateColor()
        {
            if (inputAction.WasPressedThisFrame())
            {
                return pressedColor;
            }

            if (inputAction.WasReleasedThisFrame())
            {
                return releasedColor;
            }

            return inputAction.IsPressed() ? activeColor : normalColor;
        }

        private void SetText(TMP_Text target, string value)
        {
            if (target)
            {
                target.text = value;
            }
        }
    }
}
