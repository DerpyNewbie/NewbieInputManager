using VRC.Udon.Common;
namespace DerpyNewbie.InputMan.Providers.VRChat
{
    public class NewbieInputMoveHorizontalProvider : NewbieInputVRCProvider
    {
        public override void InputMoveHorizontal(float value, UdonInputEventArgs args)
        {
            SetAxisValue(value);
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
