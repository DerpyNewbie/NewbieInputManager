namespace DerpyNewbie.InputMan.Providers.VRChat
{
    /// <summary>
    /// Base class for providers driven by VRChat's Udon input events.
    /// Derived classes only need to forward the event value through <see cref="SetAxisValue"/> or <see cref="SetButtonValue"/>.
    /// </summary>
    public abstract class NewbieInputVRCProvider : NewbieInputProvider
    {
        private float _value;

        public override float ReadValue()
        {
            return _value;
        }

        public override int GetPriority()
        {
            return 5000;
        }

        protected void SetAxisValue(float value)
        {
            _value = value;
        }

        protected void SetButtonValue(bool value)
        {
            _value = value ? 1f : 0f;
        }
    }
}
