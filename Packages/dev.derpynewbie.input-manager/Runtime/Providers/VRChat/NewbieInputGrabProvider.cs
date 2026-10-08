using VRC.Udon.Common;
namespace DerpyNewbie.InputMan.Providers.VRChat
{
    public class NewbieInputGrabProvider : NewbieInputVRCProvider
    {
        public override void InputGrab(bool value, UdonInputEventArgs args)
        {
            SetButtonValue(value);
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
