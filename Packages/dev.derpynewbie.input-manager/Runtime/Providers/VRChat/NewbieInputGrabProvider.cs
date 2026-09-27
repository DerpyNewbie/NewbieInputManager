using VRC.Udon.Common;
namespace DerpyNewbie.InputMan.Providers.VRChat
{
    public class NewbieInputGrabProvider : NewbieInputVRCProvider
    {
        private float _value;

        public override void InputGrab(bool value, UdonInputEventArgs args)
        {
            _value = value ? 1f : 0f;
        }

        public override float ReadValue()
        {
            return _value;
        }

        public override string GetName()
        {
            return "VRChat.InputGrab";
        }

        public override string GetDisplayName()
        {
            return "VRC Grab";
        }
    }
}
