namespace Test.Common;

using AutoMapper;

public static class MapperFactory
{
    public static IMapper Create()
    {
        var configurationProvider = new MapperConfiguration(cfg =>
        {

        });

        return configurationProvider.CreateMapper();
    }
}
