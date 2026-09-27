using VRC.Udon.Common;
namespace DerpyNewbie.InputMan.Providers.VRChat
{
    public class NewbieInputJumpProvider : NewbieInputVRCProvider
    {
        private float _value;

        public override void InputJump(bool value, UdonInputEventArgs args)
        {
            _value = value ? 1f : 0f;
        }

        public override float ReadValue()
        {
            return _value;
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
