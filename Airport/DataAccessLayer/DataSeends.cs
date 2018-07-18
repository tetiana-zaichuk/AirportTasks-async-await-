using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public static class DataSeends
    {
        public static List<AircraftType> AircraftTypes = new List<AircraftType>()
        {
            new AircraftType(){ AircraftId = 1, AircraftModel = "Tupolev Tu-134", SeatsNumber = 80, Carrying = 47000},
            new AircraftType(){ AircraftId = 2, AircraftModel = "Tupolev Tu-204", SeatsNumber = 196, Carrying = 107900},
            new AircraftType(){ AircraftId = 3, AircraftModel = "Ilyushin IL-62", SeatsNumber = 138, Carrying = 280300}
        };

        public static List<Aircraft> Aircraft = new List<Aircraft>()
        {
                new Aircraft(){ AircraftName = "Strong", AircraftType = new AircraftType(){  AircraftModel = "Tupolev Tu-134", SeatsNumber = 80, Carrying = 47000}, AircraftReleaseDate = new DateTime(2011, 6, 10),
                    ExploitationTimeSpan = new DateTime(2021, 6, 10)-new DateTime(2011, 6, 10)},
                new Aircraft(){ AircraftName = "Dog", AircraftType = new AircraftType(){  AircraftModel = "Tupolev Tu-204", SeatsNumber = 196, Carrying = 107900}, AircraftReleaseDate = new DateTime(2007, 6, 10),
                    ExploitationTimeSpan = new DateTime(2020, 6, 10)-new DateTime(2011, 6, 10)},
                new Aircraft(){ AircraftName = "Sky", AircraftType = new AircraftType(){  AircraftModel = "Ilyushin IL-62", SeatsNumber = 138, Carrying = 280300}, AircraftReleaseDate = new DateTime(2015, 6, 10),
                    ExploitationTimeSpan = new DateTime(2027, 6, 10)-new DateTime(2011, 6, 10)}
        };

        public static List<Ticket> Tickets = new List<Ticket>()
        {
            new Ticket(){ FlightId = 1, Price = 5000},
            new Ticket(){ FlightId = 2, Price = 3500},
            new Ticket(){ FlightId = 3, Price = 3500}
        };

        public static List<Flight> Flights = new List<Flight>()
        {
            new Flight(){ DepartureId = 1, Departure = "Kiev", DepartureTime = new DateTime(2018,7,15,19,35,00),
                Destination = "Tbilisi", ArrivalTime = new DateTime(2018,7,15,21,52,00),
                Tickets = new List<Ticket>{new Ticket(){ Price = 5000}}, },
            new Flight(){ DepartureId = 2, Departure = "Venezia", DepartureTime = new DateTime(2018,7,17,13,25,00),
                Destination = "Kiev", ArrivalTime = new DateTime(2018,7,17,16,00,00),
                Tickets = new List<Ticket>{new Ticket(){ Price = 3500}}, },
            new Flight(){ DepartureId = 3, Departure = "Kiev", DepartureTime = new DateTime(2018,7,20,13,25,00),
                Destination = "Venezia", ArrivalTime = new DateTime(2018,7,20,16,00,00),
                Tickets = new List<Ticket>{new Ticket(){ Price = 3500}}, }
        };

        public static List<Pilot> Pilots = new List<Pilot>()
        {
            new Pilot(){ CrewId = 1, FirstName = "Adam", LastName = "Black", Dob = new DateTime(1978,03,03), Experience = 9},
            new Pilot(){ CrewId = 2, FirstName = "John", LastName = "Smith", Dob = new DateTime(1983,07,11), Experience = 5},
            new Pilot(){ CrewId = 3, FirstName = "Jane", LastName = "Smith", Dob = new DateTime(1980,07,11), Experience = 7}
        };

        public static List<Stewardess> Stewardesses = new List<Stewardess>()
        {
            new Stewardess(){CrewId = 1, FirstName = "Anna", LastName = "Black", Dob = new DateTime(1993,02,03)},
            new Stewardess(){CrewId = 2, FirstName = "Anna", LastName = "Red", Dob = new DateTime(1991,01,07)},
            new Stewardess(){CrewId = 3, FirstName = "Eva", LastName = "Green", Dob = new DateTime(1987,11,10)}
        };

        public static List<Crew> Crews = new List<Crew>()
        {
            new Crew(){ Pilot = new Pilot(){ FirstName = "Adam", LastName = "Black", Dob = new DateTime(1978,03,03), Experience = 9}, Stewardesses = new List<Stewardess>{new Stewardess(){CrewId = 1, FirstName = "Anna", LastName = "Black", Dob = new DateTime(1993,02,03)}}},
            new Crew(){ Pilot = new Pilot(){ FirstName = "John", LastName = "Smith", Dob = new DateTime(1983,07,11), Experience = 5}, Stewardesses = new List<Stewardess>{new Stewardess(){CrewId = 2, FirstName = "Anna", LastName = "Red", Dob = new DateTime(1991,01,07)}}},
            new Crew(){ Pilot = new Pilot(){ FirstName = "Jane", LastName = "Smith", Dob = new DateTime(1980,07,11), Experience = 7}, Stewardesses = new List<Stewardess>{new Stewardess(){CrewId = 3, FirstName = "Eva", LastName = "Green", Dob = new DateTime(1987,11,10)}}}
        };

        public static List<Departure> Departures = new List<Departure>()
        {
            new Departure(){ Flight = Flights[0], Aircraft = Aircraft[0], Crew = Crews[0], DepartureDate = new DateTime(2018,7,15,19,35,00)},
            new Departure(){ Flight = Flights[1], Aircraft = Aircraft[1], Crew = Crews[1], DepartureDate = new DateTime(2018,7,17,14,25,00)},
            new Departure(){ Flight = Flights[2], Aircraft = Aircraft[2], Crew = Crews[2], DepartureDate = new DateTime(2018,7,20,19,35,00)}
        };

        public static List<TEntity> Set<TEntity>()
        {
            if (Aircraft is List<TEntity>)
            {
                return Aircraft as List<TEntity>;
            }
            else if (AircraftTypes is List<TEntity>)
            {
                return AircraftTypes as List<TEntity>;
            }
            else if (Tickets is List<TEntity>)
            {
                return Tickets as List<TEntity>;
            }
            else if (Flights is List<TEntity>)
            {
                return Flights as List<TEntity>;
            }
            else if (Departures is List<TEntity>)
            {
                return Departures as List<TEntity>;
            }
            else if (Pilots is List<TEntity>)
            {
                return Pilots as List<TEntity>;
            }
            else if (Stewardesses is List<TEntity>)
            {
                return Stewardesses as List<TEntity>;
            }
            else if (Crews is List<TEntity>)
            {
                return Crews as List<TEntity>;
            }
            else
            {
                throw new Exception("Something happened");
            }
        }
    }
}
