using VRC.Udon.Common;
namespace DerpyNewbie.InputMan.Providers.VRChat
{
    public class NewbieInputUseProvider : NewbieInputVRCProvider
    {
        private float _value;

        public override void InputUse(bool value, UdonInputEventArgs args)
        {
            _value = value ? 1f : 0f;
        }

        public override float ReadValue()
        {
            return _value;
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
