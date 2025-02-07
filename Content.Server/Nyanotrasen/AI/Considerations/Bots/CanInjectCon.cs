using Content.Server.AI.WorldState;
using Content.Server.AI.WorldState.States;
using Content.Server.AI.Tracking;
using Content.Shared.Damage;
using Content.Shared.MobState.Components;

namespace Content.Server.AI.Utility.Considerations.Bot
{
    public sealed class CanInjectCon : Consideration
    {
        protected override float GetScore(Blackboard context)
        {
            var target = context.GetState<TargetEntityState>().GetValue();

            if (target == null || !IoCManager.Resolve<IEntityManager>().TryGetComponent(target, out DamageableComponent? damageableComponent))
                return 0;

            if (IoCManager.Resolve<IEntityManager>().TryGetComponent(target, out RecentlyInjectedComponent recently))
                return 0f;

            if (!IoCManager.Resolve<IEntityManager>().TryGetComponent(target, out MobStateComponent mobState) || mobState.IsDead())
                return 0f;

            if (damageableComponent.TotalDamage == 0)
                return 0f;

            if (damageableComponent.TotalDamage <= 50)
                return 1f;

            if (damageableComponent.TotalDamage >= 100)
                return 1f;

            return 0f;
        }
    }
}
