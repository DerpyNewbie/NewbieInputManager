using VRC.Udon.Common;
namespace DerpyNewbie.InputMan.Providers.VRChat
{
    public class NewbieInputLookVerticalProvider : NewbieInputVRCProvider
    {
        private float _value;

        public override void InputLookVertical(float value, UdonInputEventArgs args)
        {
            _value = value;
        }

        public override float ReadValue()
        {
            return _value;
        }

        public override string GetName()
        {
            return "VRChat.InputLookVertical";
        }

        public override string GetDisplayName()
        {
            return "VRC Look Vertical";
        }
    }
}
