using NewFoodNutrients.Persistence;

namespace NewFoodNutrients.Core
{
    public interface IObjectWithState
    {
        ObjectState ObjectState { get; set; }
    }
    
}
