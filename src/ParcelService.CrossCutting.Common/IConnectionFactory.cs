using System.Data;

namespace ParcelService.CrossCutting.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
