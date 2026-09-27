using VRC.Udon.Common;
namespace DerpyNewbie.InputMan.Providers.VRChat
{
    public class NewbieInputMoveVerticalProvider : NewbieInputVRCProvider
    {
        private float _value;

        public override void InputMoveVertical(float value, UdonInputEventArgs args)
        {
            _value = value;
        }

        public override float ReadValue()
        {
            return _value;
        }

        public override string GetName()
        {
            return "VRChat.InputMoveVertical";
        }

        public override string GetDisplayName()
        {
            return "VRC Move Vertical";
        }
    }
}
