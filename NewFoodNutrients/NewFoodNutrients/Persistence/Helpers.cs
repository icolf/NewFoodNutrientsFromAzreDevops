using NewFoodNutrients.Core;
using System.Data.Entity;

namespace NewFoodNutrients.Persistence
{
    public static class Helpers
    {
        public static EntityState ConvertState(ObjectState objectState)
        {
            switch (objectState)
            {
                case ObjectState.Added:
                    return EntityState.Added;
                case ObjectState.Deleted:
                    return EntityState.Deleted;
                case ObjectState.Modified:
                    return EntityState.Modified;
                case ObjectState.Unchanged:
                    return EntityState.Unchanged;
                default:
                    return EntityState.Unchanged;
            }
        }

        public static void ApplyStateChanges(this ApplicationDbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<IObjectWithState>())
            {
                IObjectWithState stateInfo = entry.Entity;
                entry.State = ConvertState(stateInfo.ObjectState);
            }
        }
    }
}