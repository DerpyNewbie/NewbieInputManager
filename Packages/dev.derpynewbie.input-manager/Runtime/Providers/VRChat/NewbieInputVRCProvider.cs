namespace DerpyNewbie.InputMan.Providers.VRChat
{
    public abstract class NewbieInputVRCProvider : NewbieInputProvider
    {
        public override int GetPriority()
        {
            return 5000;
        }
    }
}
