using NewFoodNutrients.Persistence;

namespace NewFoodNutrients.Core
{
    //Changes
    public interface IObjectWithState
    {
        ObjectState ObjectState { get; set; }
    }
    
}
