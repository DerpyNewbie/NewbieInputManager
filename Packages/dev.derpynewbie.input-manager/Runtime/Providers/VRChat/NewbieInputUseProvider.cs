using VRC.Udon.Common;
namespace DerpyNewbie.InputMan.Providers.VRChat
{
    public class NewbieInputUseProvider : NewbieInputVRCProvider
    {
        public override void InputUse(bool value, UdonInputEventArgs args)
        {
            SetButtonValue(value);
        }

        public override string GetName()
        {
            return "VRChat.InputUse";
        }

        public override string GetDisplayName()
        {
            return "VRC Use";
        }
    }
}
