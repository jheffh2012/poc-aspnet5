using poc.AspNet5.Ioc.Entities;

namespace poc.AspNet5.Domain.Interfaces.Services
{
    public interface IPrevisaoTempoService
    {
        PrevisaoTempoCidade GetPrevisaoPorIp(string Ip);
    }
}
