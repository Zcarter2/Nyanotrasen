using Robust.Shared.GameStates;
using Robust.Shared.Serialization;

namespace Content.Shared.Carrying
{
    [RegisterComponent, NetworkedComponent, Friend(typeof(CarryingSlowdownSystem))]

    public sealed class CarryingSlowdownComponent : Component
    {
        [DataField("walkModifier", required: true)] [ViewVariables(VVAccess.ReadWrite)]
        public float WalkModifier = 1.0f;

        [DataField("sprintModifier", required: true)] [ViewVariables(VVAccess.ReadWrite)]
        public float SprintModifier = 1.0f;
    }

    [Serializable, NetSerializable]
    public sealed class CarryingSlowdownComponentState : ComponentState
    {
        public float WalkModifier;
        public float SprintModifier;
        public CarryingSlowdownComponentState(float walkModifier, float sprintModifier)
        {
            WalkModifier = walkModifier;
            SprintModifier = sprintModifier;
        }
    }
}