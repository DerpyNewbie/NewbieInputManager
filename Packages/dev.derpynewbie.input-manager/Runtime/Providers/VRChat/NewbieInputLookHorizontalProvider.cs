using VRC.Udon.Common;
namespace DerpyNewbie.InputMan.Providers.VRChat
{
    public class NewbieInputLookHorizontalProvider : NewbieInputVRCProvider
    {
        private float _value;

        public override void InputLookHorizontal(float value, UdonInputEventArgs args)
        {
            _value = value;
        }

        public override float ReadValue()
        {
            return _value;
        }

        public override string GetName()
        {
            return "VRChat.InputLookHorizontal";
        }

        public override string GetDisplayName()
        {
            return "VRC Look Horizontal";
        }
    }
}
