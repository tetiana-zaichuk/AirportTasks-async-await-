using System.Linq;

namespace DataAccessLayer
{
    public static class DbInitializer
    {
        public static void Initialize(AirportContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Aircrafts.Any())
            {
                context.Aircrafts.AddRange(DataSeends.Aircraft);
                context.SaveChanges();
            }
            if (!context.AircraftsTypes.Any())
            {
                context.AircraftsTypes.AddRange(DataSeends.AircraftTypes);
                context.SaveChanges();
            }
            if (!context.Crews.Any())
            {
                context.Crews.AddRange(DataSeends.Crews);
                context.SaveChanges();
            }
            if (!context.Departures.Any())
            {
                context.Departures.AddRange(DataSeends.Departures);
                context.SaveChanges();
            }
            if (!context.Flights.Any())
            {
                context.Flights.AddRange(DataSeends.Flights);
                context.SaveChanges();
            }
            if (!context.Pilots.Any())
            {
                context.Pilots.AddRange(DataSeends.Pilots);
                context.SaveChanges();
            }
            if (!context.Stewardesses.Any())
            {
                context.Stewardesses.AddRange(DataSeends.Stewardesses);
                context.SaveChanges();
            }
            if (!context.Tickets.Any())
            {
                context.Tickets.AddRange(DataSeends.Tickets);
                context.SaveChanges();
            }
        }
    }
}
