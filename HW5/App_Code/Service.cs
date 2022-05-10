using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	public float GetLat(string place)
	{
		
		
			float lat = 0;
			string url = @"http://api.positionstack.com/v1/forward?&access_key=bc486d7a5c892f164b5ea4835b486c99&limit=1&query=" + place;
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.ContentType = "application/json";
			WebResponse response = request.GetResponse();
			Stream dataStream = response.GetResponseStream();
			StreamReader sreader = new StreamReader(dataStream);
			string responsereader = sreader.ReadToEnd();
			response.Close();
			Position positionObj = JsonConvert.DeserializeObject<Position>(responsereader);
			lat = float.Parse(positionObj.data[0].latitude);
			return lat;
		
        
			
        
	}

	public float GetLon(string place)
    {

		string url = @"http://api.positionstack.com/v1/forward?access_key=bc486d7a5c892f164b5ea4835b486c99&limit=1&query=" + place;
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.ContentType = "application/json";
		WebResponse response = request.GetResponse();
		Stream dataStream = response.GetResponseStream();
		StreamReader sreader = new StreamReader(dataStream);
		string responsereader = sreader.ReadToEnd();
		response.Close();
		Position positionObj = JsonConvert.DeserializeObject<Position>(responsereader);
		return float.Parse(positionObj.data[0].longitude);
	}

	public float GetSolar(string place)
    {
		string url = @"https://api.openweathermap.org/data/2.5/onecall?appid=0f7beb7531aa3f72cb76ad6010b51ccf&exclude=hourly,current,alerts,minutely&lat=" + GetLat(place) + "&lon=" + GetLon(place);
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.ContentType = "application/json";
		WebResponse response = request.GetResponse();
		Stream dataStream = response.GetResponseStream();
		StreamReader sreader = new StreamReader(dataStream);
		string responsereader = sreader.ReadToEnd();
		response.Close();

		Solar solarObj = JsonConvert.DeserializeObject<Solar>(responsereader);

		return solarObj.daily[0].uvi;

	}

	public float GetWind(string place)
    {
		string url = @"https://api.openweathermap.org/data/2.5/onecall?appid=0f7beb7531aa3f72cb76ad6010b51ccf&exclude=hourly,current,alerts,minutely&lat=" + GetLat(place) + "&lon=" + GetLon(place);
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.ContentType = "application/json";
		WebResponse response = request.GetResponse();
		Stream dataStream = response.GetResponseStream();
		StreamReader sreader = new StreamReader(dataStream);
		string responsereader = sreader.ReadToEnd();
		response.Close();

		Solar windObj = JsonConvert.DeserializeObject<Solar>(responsereader);

		return windObj.daily[0].wind_speed;
	}

	
}
