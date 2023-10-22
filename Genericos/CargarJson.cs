using System.IO;
using Newtonsoft.Json;

namespace LoginOrange.Genericos
{
    public class CargarJson
    {
       public POJO.LoginData login_data()
        {
            var Json = JsonConvert.DeserializeObject<POJO.LoginData>(File.ReadAllText(@"..\..\..\Data\login.json"));
            return Json;
        }
    }
}
