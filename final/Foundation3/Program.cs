using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "Anystate", "12345");
        Address address2 = new Address("456 Oak St", "Othertown", "Otherstate", "67890");
        Address address3 = new Address("789 Pine St", "Sometown", "Somestate", "11223");

        Lecture lecture = new Lecture("Tech Talk", "A talk on the latest in technology.", new DateTime(2024, 7, 10), new TimeSpan(18, 0, 0), address1, "John Doe", 100);
        Reception reception = new Reception("Company Gala", "An evening of networking and celebration.", new DateTime(2024, 8, 20), new TimeSpan(19, 0, 0), address2, "rsvp@company.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Summer Fest", "A fun-filled day with music and food.", new DateTime(2024, 6, 15), new TimeSpan(12, 0, 0), address3, "Sunny");

        List<Event> events = new List<Event> { lecture, reception, outdoorGathering };

        foreach (var eventItem in events)
        {
            Console.WriteLine("Standard Details:");
            Console.WriteLine(eventItem.GetStandardDetails());
            Console.WriteLine();

            Console.WriteLine("Full Details:");
            Console.WriteLine(eventItem.GetFullDetails());
            Console.WriteLine();

            Console.WriteLine("Short Description:");
            Console.WriteLine(eventItem.GetShortDescription());
            Console.WriteLine();
        }
    }
}