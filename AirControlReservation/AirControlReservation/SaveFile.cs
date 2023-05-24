using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AirControlReservation;

public class SaveFile: ISave
{
    public static readonly string FILE_NAME = "airplane.json";

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
                Save(AirplaneFactory.CreateAirplane()).ConfigureAwait(true);
            }
            var json = File.ReadAllText(FILE_NAME);
            var airplane =  JsonConvert.DeserializeObject<Airplane>(json, serializerSettings);
            if (airplane is null)
            {
                airplane = AirplaneFactory.CreateAirplane();
                Save(airplane).ConfigureAwait(true);
            }

            return airplane;
        }
    }

	public async Task Save(Airplane airplane)
	{
		if (File.Exists(FILE_NAME))
		{
			File.Delete(FILE_NAME);

        }
        
        var json = JsonConvert.SerializeObject(airplane, serializerSettings);
        await File.WriteAllTextAsync(FILE_NAME, json);

        return;
	}
}

