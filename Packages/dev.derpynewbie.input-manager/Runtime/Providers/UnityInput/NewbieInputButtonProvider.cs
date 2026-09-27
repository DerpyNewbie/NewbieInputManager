using UnityEngine;
namespace DerpyNewbie.InputMan.Providers.UnityInput
{
    public class NewbieInputButtonProvider : NewbieInputUnityProvider
    {
        [SerializeField]
        private string buttonName;
        [SerializeField]
        private string displayName;

        public override float ReadValue()
        {
            return Input.GetButton(buttonName) ? 1 : 0;
        }

        public override string GetName()
        {
            return $"Button.{buttonName}";
        }

        public override string GetDisplayName()
        {
            return displayName;
        }
        
        public override int GetPriority()
        {
            return 1000;
        }
    }
}
