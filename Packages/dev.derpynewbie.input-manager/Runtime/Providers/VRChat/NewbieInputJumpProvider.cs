using VRC.Udon.Common;
namespace DerpyNewbie.InputMan.Providers.VRChat
{
    public class NewbieInputJumpProvider : NewbieInputVRCProvider
    {
        public override void InputJump(bool value, UdonInputEventArgs args)
        {
            SetButtonValue(value);
        }

        public override string GetName()
        {
            return "VRChat.InputJump";
        }

        public override string GetDisplayName()
        {
            return "VRC Jump";
        }
    }
}
