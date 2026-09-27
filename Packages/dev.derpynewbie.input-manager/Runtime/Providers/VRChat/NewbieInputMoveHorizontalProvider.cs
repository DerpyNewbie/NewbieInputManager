using VRC.Udon.Common;
namespace DerpyNewbie.InputMan.Providers.VRChat
{
    public class NewbieInputMoveHorizontalProvider : NewbieInputVRCProvider
    {
        private float _value;

        public override void InputMoveHorizontal(float value, UdonInputEventArgs args)
        {
            _value = value;
        }

        public override float ReadValue()
        {
            return _value;
        }

        public override string GetName()
        {
            return "VRChat.InputMoveHorizontal";
        }

        public override string GetDisplayName()
        {
            return "VRC Move Horizontal";
        }
    }
}
