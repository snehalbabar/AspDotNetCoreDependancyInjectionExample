using ServiceContracts;

namespace ServiceLayer;

public class CitiesService : ICitiesService , IDisposable
{
    private List<string> _cities;


    private Guid _serviceInstaceId;

    public Guid ServiceInstaceId {
        get {

            return _serviceInstaceId;
        }
    }

    public CitiesService()
    {
        
        _serviceInstaceId = Guid.NewGuid();
        _cities = new List<string>()
        {
            "London",
            "paris",
            "Delhi",
            "Pune",
            "Dallas"
        };

    }

    public List<string> GetCities()
    {
        return _cities;

    }

    public void Dispose()
    {
      
    }

}

