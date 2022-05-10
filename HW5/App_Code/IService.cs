using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

	[OperationContract]
	[WebGet(UriTemplate = "lat?place={place}", ResponseFormat = WebMessageFormat.Json)]
	float GetLat(string place);

	[OperationContract]
	[WebGet(UriTemplate = "lon?place={place}", ResponseFormat = WebMessageFormat.Json)]
	float GetLon(string place);

	[OperationContract]
	[WebGet(UriTemplate = "solar?place={place}", ResponseFormat = WebMessageFormat.Json)]
	float GetSolar(string place);

	[OperationContract]
	[WebGet(UriTemplate = "wind?place={place}", ResponseFormat = WebMessageFormat.Json)]
	float GetWind(string place);

	
}

public class Position
{
	public List<LatLon> data { get; set; }
}

public class LatLon
{
	public string latitude { get; set; }
	public string longitude { get; set; }
}

public class Solar
{
	public List<Output_Data> daily { get; set; }
}

public class Output_Data
{
	public float uvi { get; set; }

	public float wind_speed { get; set; }
}

