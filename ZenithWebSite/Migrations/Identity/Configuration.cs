namespace ZenithWebSite.Migrations.Identity
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZenithDataLib.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithWebSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Identity";
        }

        protected override void Seed(ZenithWebSite.Models.ApplicationDbContext context)
        {
            setRoles(context);
            context.SaveChanges();
            setUsers(context);
            context.SaveChanges();
            context.Activities.AddOrUpdate(a => a.ActivityId, getActivities());
            context.SaveChanges();
            context.Events.AddOrUpdate(e => e.EventId, getEvents(context));
            context.SaveChanges();
        }

        private void setRoles(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Member" };

                manager.Create(role);
            }
        }

        private void setUsers(ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "a"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "a", Email = "a@a.a" };

                manager.Create(user, "P@$$w0rd");
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "m"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "m", Email = "m@m.m" };

                manager.Create(user, "P@$$w0rd");
                manager.AddToRole(user.Id, "Member");
            }
        }


        private Event[] getEvents(ApplicationDbContext context)
        {
            var events = new List<Event>
            {
                new Event {EventId = 1, EventFrom =  new DateTime(2017, 02, 08, 8, 30, 0), EventTo =  new DateTime(2017, 02, 08, 10, 20, 0), EnteredBy = "a", ActivityId = 1, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 1).CreationDate, IsActive = false},
                new Event {EventId = 2, EventFrom = new DateTime(2017, 02, 08, 11, 30, 0), EventTo = new DateTime(2017, 02, 08, 12, 20, 0), EnteredBy = "a", ActivityId = 2, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 2).CreationDate, IsActive = true},
                new Event {EventId = 3, EventFrom = new DateTime(2017, 02, 08, 16, 30, 0), EventTo = new DateTime(2017, 02, 08, 18, 20, 0), EnteredBy = "a", ActivityId = 3, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 3).CreationDate, IsActive = false},
                new Event {EventId = 4, EventFrom = new DateTime(2017, 02, 09, 9, 30, 0), EventTo = new DateTime(2017, 02, 09, 11, 20, 0), EnteredBy = "a", ActivityId = 4, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 4).CreationDate, IsActive = false},
                new Event {EventId = 5, EventFrom = new DateTime(2017, 02, 09, 12, 30, 0), EventTo = new DateTime(2017, 02, 09, 15, 20, 0), EnteredBy = "a", ActivityId = 5, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 5).CreationDate, IsActive = true},
                new Event {EventId = 6, EventFrom = new DateTime(2017, 02, 10, 16, 30, 0), EventTo = new DateTime(2017, 02, 10, 18, 20, 0), EnteredBy = "a", ActivityId = 6, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 6).CreationDate, IsActive = true},
                new Event {EventId = 7, EventFrom = new DateTime(2017, 02, 11, 9, 30, 0), EventTo = new DateTime(2017, 02, 11, 10, 20, 0), EnteredBy = "a", ActivityId = 7, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 7).CreationDate, IsActive = false},
                new Event {EventId = 8, EventFrom = new DateTime(2017, 02, 11, 12, 30, 0), EventTo = new DateTime(2017, 02, 11, 13, 20, 0), EnteredBy = "a", ActivityId = 8, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 8).CreationDate, IsActive = false},
                new Event {EventId = 9, EventFrom = new DateTime(2017, 02, 11, 14, 30, 0), EventTo = new DateTime(2017, 02, 11, 15, 50, 0), EnteredBy = "a", ActivityId = 9, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 9).CreationDate, IsActive = true},
                new Event {EventId = 10, EventFrom = new DateTime(2017, 02, 12, 7, 0, 0), EventTo = new DateTime(2017, 02, 12, 8, 20, 0), EnteredBy = "a", ActivityId = 10, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 10).CreationDate, IsActive = true},
                new Event {EventId = 11, EventFrom = new DateTime(2017, 02, 12, 8, 30, 0), EventTo = new DateTime(2017, 02, 12, 9, 20, 0), EnteredBy = "a", ActivityId = 11, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 11).CreationDate, IsActive = false},
                new Event {EventId = 12, EventFrom = new DateTime(2017, 02, 13, 11, 30, 0), EventTo = new DateTime(2017, 02, 13, 13, 20, 0), EnteredBy = "a", ActivityId = 12, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 12).CreationDate, IsActive = true},
                new Event {EventId = 13, EventFrom =new DateTime(2017, 02, 13, 14, 30, 0), EventTo = new DateTime(2017, 02, 13, 16, 20, 0), EnteredBy = "a", ActivityId = 13, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 13).CreationDate, IsActive = false},
                new Event {EventId = 14, EventFrom = new DateTime(2017, 02, 13, 16, 30, 0), EventTo = new DateTime(2017, 02, 13, 18, 20, 0), EnteredBy = "a", ActivityId = 14, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 14).CreationDate, IsActive = false},
                new Event {EventId = 15, EventFrom = new DateTime(2017, 02, 14, 7, 30, 0), EventTo =new DateTime(2017, 02, 14, 8, 20, 0), EnteredBy = "a", ActivityId = 15, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 15).CreationDate, IsActive = true},
                new Event {EventId = 16, EventFrom = new DateTime(2017, 02, 14, 9, 30, 0), EventTo =new DateTime(2017, 02, 14, 10, 20, 0), EnteredBy = "a", ActivityId = 14, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 14).CreationDate, IsActive = true},
                new Event {EventId = 17, EventFrom = new DateTime(2017, 02, 15, 10, 30, 0), EventTo =new DateTime(2017, 02, 15, 12, 20, 0), EnteredBy = "a", ActivityId = 13, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 13).CreationDate, IsActive = false},
                new Event {EventId = 18, EventFrom = new DateTime(2017, 02, 15, 13, 30, 0), EventTo =new DateTime(2017, 02, 15, 16, 20, 0), EnteredBy = "a", ActivityId = 12, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 12).CreationDate, IsActive = true},
                new Event {EventId = 19, EventFrom = new DateTime(2017, 02, 16, 7, 30, 0), EventTo =new DateTime(2017, 02, 16, 10, 20, 0), EnteredBy = "a", ActivityId = 11, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 11).CreationDate, IsActive = false},
                new Event {EventId = 20, EventFrom = new DateTime(2017, 02, 16, 11, 30, 0), EventTo =new DateTime(2017, 02, 16, 14, 20, 0), EnteredBy = "a", ActivityId = 10, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 10).CreationDate, IsActive = true},
                new Event {EventId = 21, EventFrom = new DateTime(2017, 02, 16, 15, 30, 0), EventTo =new DateTime(2017, 02, 16, 18, 20, 0), EnteredBy = "a", ActivityId = 9, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 9).CreationDate, IsActive = true},
                new Event {EventId = 22, EventFrom = new DateTime(2017, 02, 17, 8, 30, 0), EventTo =new DateTime(2017, 02, 17, 10, 20, 0), EnteredBy = "a", ActivityId = 8, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 8).CreationDate, IsActive = true},
                new Event {EventId = 23, EventFrom = new DateTime(2017, 02, 17, 13, 30, 0), EventTo =new DateTime(2017, 02, 17, 16, 20, 0), EnteredBy = "a", ActivityId = 7, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 7).CreationDate, IsActive = false},
                new Event {EventId = 24, EventFrom = new DateTime(2017, 02, 17, 17, 30, 0), EventTo =new DateTime(2017, 02, 17, 20, 20, 0), EnteredBy = "a", ActivityId = 6, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 6).CreationDate, IsActive = true},
                new Event {EventId = 25, EventFrom = new DateTime(2017, 02, 18, 9, 30, 0), EventTo =new DateTime(2017, 02, 18, 10, 20, 0), EnteredBy = "a", ActivityId = 5, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 5).CreationDate, IsActive = false},
                new Event {EventId = 26, EventFrom = new DateTime(2017, 02, 18, 11, 30, 0), EventTo =new DateTime(2017, 02, 18, 12, 20, 0), EnteredBy = "a", ActivityId = 4, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 4).CreationDate, IsActive = true},
                new Event {EventId = 27, EventFrom = new DateTime(2017, 02, 19, 6, 30, 0), EventTo =new DateTime(2017, 02, 19, 8, 20, 0), EnteredBy = "a", ActivityId = 3, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 3).CreationDate, IsActive = true},
                new Event {EventId = 28, EventFrom = new DateTime(2017, 02, 19, 10, 30, 0), EventTo =new DateTime(2017, 02, 19, 12, 20, 0), EnteredBy = "a", ActivityId = 2, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 2).CreationDate, IsActive = true},
                new Event {EventId = 29, EventFrom = new DateTime(2017, 02, 20, 13, 30, 0), EventTo =new DateTime(2017, 02, 20, 16, 20, 0), EnteredBy = "a", ActivityId = 1, CreationDate = context.Activities.FirstOrDefault(a => a.ActivityId == 1).CreationDate, IsActive = false}
            };

            return events.ToArray();
        }

        private Activity[] getActivities()
        {
            var activities = new List<Activity>()
            {
                new Activity {ActivityId = 1, Description = "Senior's Golf Tournament", CreationDate = new DateTime(2017, 02, 04)},
                new Activity {ActivityId = 2, Description = "Leadership General Assembly Meeting", CreationDate = new DateTime(2017, 02, 04)},
                new Activity {ActivityId = 3, Description = "Youth Bowling Tournament", CreationDate = new DateTime(2017, 02, 04)},
                new Activity {ActivityId = 4, Description = "Young ladies cooking lessons", CreationDate = new DateTime(2017, 02, 04)},
                new Activity {ActivityId = 5, Description = "Youth craft leassons", CreationDate = new DateTime(2017, 02, 04)},
                new Activity {ActivityId = 6, Description = "Youth choir practice", CreationDate = new DateTime(2017, 02, 04)},
                new Activity {ActivityId = 7, Description = "Lunch", CreationDate = new DateTime(2017, 02, 05)},
                new Activity {ActivityId = 8, Description = "Pancake Breakfast", CreationDate = new DateTime(2017, 02, 05)},
                new Activity {ActivityId = 9, Description = "Swimming Lessons for the youth", CreationDate = new DateTime(2017, 02, 05)},
                new Activity {ActivityId = 10, Description = "Swimming Exercise for parents", CreationDate = new DateTime(2017, 02, 05)},
                new Activity {ActivityId = 11, Description = "Bingo Tournament", CreationDate = new DateTime(2017, 02, 05)},
                new Activity {ActivityId = 12, Description = "BBQ Lunch", CreationDate = new DateTime(2017, 02, 05)},
                new Activity {ActivityId = 13, Description = "Garage Sale", CreationDate = new DateTime(2017, 02, 05)},
                new Activity {ActivityId = 14, Description = "Youth Basketball Tournament", CreationDate = new DateTime(2017, 02, 06)},
                new Activity {ActivityId = 15, Description = "Senior Volleyball Tournament", CreationDate = new DateTime(2017, 02, 06)}
            };

            return activities.ToArray();
        }
    }
}