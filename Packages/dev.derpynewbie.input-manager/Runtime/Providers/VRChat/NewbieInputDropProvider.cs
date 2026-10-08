using VRC.Udon.Common;
namespace DerpyNewbie.InputMan.Providers.VRChat
{
    public class NewbieInputDropProvider : NewbieInputVRCProvider
    {
        public override void InputDrop(bool value, UdonInputEventArgs args)
        {
            SetButtonValue(value);
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
