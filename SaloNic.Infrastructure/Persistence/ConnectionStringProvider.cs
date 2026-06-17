using SaloNic.Application.Common.Interfaces;

namespace SaloNic.Infrastructure.Persistence;

public sealed class ConnectionStringProvider(string defaultConnection) : IConnectionStringProvider
{
    public string DefaultConnection { get; } = defaultConnection;
}
