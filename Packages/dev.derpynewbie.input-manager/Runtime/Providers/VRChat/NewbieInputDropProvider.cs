using VRC.Udon.Common;
namespace DerpyNewbie.InputMan.Providers.VRChat
{
    public class NewbieInputDropProvider : NewbieInputVRCProvider
    {
        private float _value;

        public override void InputDrop(bool value, UdonInputEventArgs args)
        {
            _value = value ? 1f : 0f;
        }

        public override float ReadValue()
        {
            return _value;
        }

        public override string GetName()
        {
            return "VRChat.InputDrop";
        }

        public override string GetDisplayName()
        {
            return "VRC Drop";
        }
    }
}
