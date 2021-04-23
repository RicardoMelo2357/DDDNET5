using AutoMapper;

namespace Infra.Persistencia.AutoMapper
{
    public class AutoMapperConfig
    {
        public MapperConfiguration Config() => new MapperConfiguration(config => { config.AddProfile<Mapper>(); config.AllowNullCollections = true; });
    }
}
