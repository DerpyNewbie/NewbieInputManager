using UdonSharp;
namespace DerpyNewbie.InputMan.UI
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class InputActionRebinderElementView : UdonSharpBehaviour
    {
        public InputActionRebinderView rebinderView;
        public NewbieInputAction targetInputAction;

        public override void Interact()
        {
            rebinderView.BeginRebinding(targetInputAction);
        }
    }
}
