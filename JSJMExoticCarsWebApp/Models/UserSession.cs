using System.Text.Json;
using System.Text;

namespace JSJMExoticCarsWebApp.Models
{
    public class UserSession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Funds { get; set; }
        public List<Car> Cars { get; set; } = new List<Car>();


        public static byte[] ConvertUserSessionToBytes(UserSession userSession)
        {
            string userSessionJson = JsonSerializer.Serialize(userSession);

            byte[] userSessionBytes = Encoding.UTF8.GetBytes(userSessionJson);

            return userSessionBytes;
        }

        public static UserSession ConvertBytesToUserSession(byte[] bytes)
        {
            if(bytes == null) return new UserSession();

            string userSessionJson = Encoding.UTF8.GetString(bytes);

            UserSession userSession = JsonSerializer.Deserialize<UserSession>(userSessionJson);

            return userSession;
        }

        public static void UpdateUser(UserSession userSession, CarDbContext carDbContext)
        {
            var user = carDbContext.Users.FirstOrDefault(m => m.Id == userSession.Id);

            if (user == null) return;

            user.Name = userSession.Name;
            user.Funds = userSession.Funds;
            user.Cars = userSession.Cars;

            carDbContext.Users.Update(user);
            carDbContext.SaveChanges();
        }
    }
}
