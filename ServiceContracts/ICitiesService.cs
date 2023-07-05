namespace ServiceContracts;
public interface ICitiesService
{
    Guid ServiceInstaceId { get; }

    List<string> GetCities();
}

