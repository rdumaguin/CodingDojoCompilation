using LostInTheWoods.Models;
using System.Collections.Generic;

namespace LostInTheWoods.Factories
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}
