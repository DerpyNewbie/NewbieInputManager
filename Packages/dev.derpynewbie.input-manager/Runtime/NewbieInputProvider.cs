using UdonSharp;
namespace DerpyNewbie.InputMan
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public abstract class NewbieInputProvider : UdonSharpBehaviour
    {
        /// <summary>
        /// Return the amount of input from this provider
        /// </summary>
        /// <returns>
        /// In range of -1 to 1.
        /// 0 being the rest position.
        /// </returns>
        public abstract float ReadValue();

        /// <summary>
        /// Return the name of this input provider
        /// </summary>
        /// <returns>The name of this input provider</returns>
        public abstract string GetName();

        /// <summary>
        /// Return the display name of this input provider
        /// </summary>
        /// <returns>The display name of this input provider</returns>
        public abstract string GetDisplayName();

        /// <summary>
        /// Return the priority of this input provider
        /// </summary>
        /// <remarks>The larger, the higher the priority</remarks>
        /// <returns>The priority of this input provider</returns>
        public abstract int GetPriority();
    }
}
