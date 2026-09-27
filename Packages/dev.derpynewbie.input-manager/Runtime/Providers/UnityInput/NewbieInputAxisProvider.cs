using UnityEngine;
namespace DerpyNewbie.InputMan.Providers.UnityInput
{
    public class NewbieInputAxisProvider : NewbieInputUnityProvider
    {
        [SerializeField]
        private string axisName;
        [SerializeField]
        private string displayName;

        public override float ReadValue()
        {
            return Input.GetAxis(axisName);
        }

        public override string GetName()
        {
            return $"Axis.{axisName}";
        }

        public override string GetDisplayName()
        {
            return displayName;
        }
        
        public override int GetPriority()
        {
            return 2000;
        }
    }
}
