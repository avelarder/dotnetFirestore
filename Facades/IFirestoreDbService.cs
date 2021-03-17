using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Facades
{
    public interface IFirestoreDbService
    {
        IAsyncEnumerable<Team> GetTeams();
    }
}