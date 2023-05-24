using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AirControlReservation;

public class SaveFile: ISave
{
    public static readonly string FILE_NAME = "airplane.json";

    private Airplane _airplane;

    public readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        }
    };

    public Airplane Airplane
    {
        get
        {
            if (!File.Exists(FILE_NAME))
            {
                _airplane = AirplaneFactory.CreateAirplane();
                Save().ConfigureAwait(true);
            }
            var json = File.ReadAllText(FILE_NAME);
            var airplane =  JsonConvert.DeserializeObject<Airplane>(json, serializerSettings);
            if (airplane is null)
            {
                _airplane = AirplaneFactory.CreateAirplane();
                Save().ConfigureAwait(true);
            }
            else
            {
                _airplane = airplane;
            }

            return _airplane;
        }
    }

	public async Task Save()
	{
		if (File.Exists(FILE_NAME))
		{
			File.Delete(FILE_NAME);

        }
        
        var json = JsonConvert.SerializeObject(_airplane, serializerSettings);
        await File.WriteAllTextAsync(FILE_NAME, json);

        return;
	}
}

