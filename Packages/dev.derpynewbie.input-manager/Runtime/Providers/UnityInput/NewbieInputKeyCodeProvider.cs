using UdonSharp;
using UnityEngine;
namespace DerpyNewbie.InputMan.Providers.UnityInput
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class NewbieInputKeyCodeProvider : NewbieInputUnityProvider
    {
        [SerializeField]
        private KeyCode keyCode;

        public override float ReadValue()
        {
            return Input.GetKey(keyCode) ? 1.0f : 0.0f;
        }

        public override string GetName()
        {
            return $"KeyCode.{keyCode.ToString()}";
        }

        public override string GetDisplayName()
        {
            return $"Key {keyCode.ToString()}";
        }

        public override int GetPriority()
        {
            return 0;
        }
    }
}
