using VRC.Udon.Common;
namespace DerpyNewbie.InputMan.Providers.VRChat
{
    public class NewbieInputLookVerticalProvider : NewbieInputVRCProvider
    {
        public override void InputLookVertical(float value, UdonInputEventArgs args)
        {
            SetAxisValue(value);
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
