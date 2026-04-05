using Bogus;
using EventHorizon.API.Models;

namespace EventHorizon.API.Data;

public static class DbSeeder
{
    public static void Seed(ApplicationDbContext context)
    {
        if (context.Organizers.Any() || context.Events.Any()) return;

        var organizerFaker = new Faker<Organizer>()
            .RuleFor(o => o.Name, f => f.Company.CompanyName())
            .RuleFor(o => o.Email, f => f.Internet.Email());

        var organizers = organizerFaker.Generate(15);
        context.Organizers.AddRange(organizers);
        context.SaveChanges();

        var eventFaker = new Faker<Event>()
            .RuleFor(e => e.Title, f => f.Commerce.ProductName() + " Summit")
            .RuleFor(e => e.Description, f => f.Lorem.Paragraph())
            .RuleFor(e => e.Date, f => f.Date.FutureOffset(1).DateTime)
            .RuleFor(e => e.CurrentAttendees, f => f.Random.Int(10, 1000))
            .RuleFor(e => e.OrganizerId, f => f.PickRandom(organizers).Id);

        var events = eventFaker.Generate(50);
        context.Events.AddRange(events);
        context.SaveChanges();
    }
}
