using System.Text.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;

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
			var user = carDbContext.Users.FirstOrDefault(u => u.Id == userSession.Id); 

            if (user == null) return;

            user.Name = userSession.Name;
            user.Funds = userSession.Funds;

			foreach (var car in userSession.Cars)
			{
				var existingCar = carDbContext.Cars.FirstOrDefault(c => c.Id == car.Id);
				if (existingCar != null)
				{
                    user.Cars.Add(existingCar);
                    carDbContext.Cars.Update(existingCar);
				}
				else
				{
					user.Cars.Add(car);
                    carDbContext.Cars.Update(car);
				}
			}



            carDbContext.Users.Update(user);
            carDbContext.SaveChanges();
        }

        public static UserSession UpdateUserSession(UserSession userSession, CarDbContext cdbc)
        {
            var user = cdbc.Users.Include(m => m.Cars).FirstOrDefault(u => u.Id == userSession.Id);

            if (user == null) return new UserSession();

            userSession.Name = user.Name;
            userSession.Funds = user.Funds;
            userSession.Cars = user.Cars;

            return userSession;
        }
    }
}
