using VRC.Udon.Common;
namespace DerpyNewbie.InputMan.Providers.VRChat
{
    public class NewbieInputLookHorizontalProvider : NewbieInputVRCProvider
    {
        public override void InputLookHorizontal(float value, UdonInputEventArgs args)
        {
            SetAxisValue(value);
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
