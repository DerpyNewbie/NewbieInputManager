using VRC.Udon.Common;
namespace DerpyNewbie.InputMan.Providers.VRChat
{
    public class NewbieInputMoveVerticalProvider : NewbieInputVRCProvider
    {
        public override void InputMoveVertical(float value, UdonInputEventArgs args)
        {
            SetAxisValue(value);
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
