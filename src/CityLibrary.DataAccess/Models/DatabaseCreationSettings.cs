namespace CityLibrary.DataAccess.Models;

public class DatabaseCreationSettings
{
    public bool ReCreateDatabaseAtFirstStartup { get; init; }
    public bool AddTestDataWhenCreatingDatabase { get; init; }
}
