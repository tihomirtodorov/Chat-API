using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Domain.Entities;
using Domain.Enums;

namespace Persistence.Utilities
{
    public static class Configuration
    {
        public static IEnumerable<Event> GetEvents()
        {
            return new[]
            {
                new Event
                {
                    Id = Guid.Parse("e48d85f9-a4f2-4301-943b-a39437df0a23"),
                    CreatedOn = DateTime.Parse("2021-01-02T12:15:01.453616Z"),
                    Sender = "Bob",
                    Receiver = null,
                    EventType = EventType.Enter,
                    Message = "Bob enters the room"
                },
                new Event
                {
                    Id = Guid.Parse("6175a53d-aced-400b-b8ea-af7815e64d1f"),
                    CreatedOn = DateTime.Parse("2021-01-02T12:10:01.453616Z"),
                    Sender = "Kate",
                    Receiver = null,
                    EventType = EventType.Enter,
                    Message = "Kate enters the room"
                },
                new Event
                {
                    Id = Guid.Parse("af4e4af8-5973-4803-ab55-c00d10ba4593"),
                    CreatedOn = DateTime.Parse("2021-01-02T12:05:01.453616Z"),
                    Sender = "George",
                    Receiver = null,
                    EventType = EventType.Enter,
                    Message = "George enters the room"
                },
                new Event
                {
                    Id = Guid.Parse("493b0443-24a8-4143-ac80-f7f9751825d8"),
                    CreatedOn = DateTime.Parse("2021-01-02T12:07:03.453616Z"),
                    Sender = "George",
                    Receiver = null,
                    EventType = EventType.Comment,
                    Message = "Bob - how are you today?"
                },
                new Event
                {
                    Id = Guid.Parse("f796cafc-e3f6-4c65-a54b-17eb5f335efc"),
                    CreatedOn = DateTime.Parse("2021-01-02T12:07:01.453616Z"),
                    Sender = "Bob",
                    Receiver = null,
                    EventType = EventType.Comment,
                    Message = "Hey, Kate - high five?"
                },
                new Event
                {
                    Id = Guid.Parse("6ddf491d-e86b-4bbe-811f-ffe9aeb15f3f"),
                    CreatedOn = DateTime.Parse("2021-01-02T17:07:01.453616Z"),
                    Sender = "Bob",
                    Receiver = null,
                    EventType = EventType.Comment,
                    Message = "Good morning everybody!"
                },
                new Event
                {
                    Id = Guid.Parse("e5d25bbd-18f6-4b80-b4be-5eca0b40e5e1"),
                    CreatedOn = DateTime.Parse("2021-01-02T12:07:10.453616Z"),
                    Sender = "Bob",
                    Receiver = "Kate",
                    EventType = EventType.HighFive,
                    Message = "Bob high-fives Kate"
                },
                new Event
                {
                    Id = Guid.Parse("55a8873e-97bd-4632-a8c0-513ce2b2fe26"),
                    CreatedOn = DateTime.Parse("2021-01-02T12:08:10.453616Z"),
                    Sender = "George",
                    Receiver = "Kate",
                    EventType = EventType.HighFive,
                    Message = "George high-fives Kate"
                },
                new Event
                {
                    Id = Guid.Parse("cbfc0a7c-5084-4b4b-a36c-6bb378bb8839"),
                    CreatedOn = DateTime.Parse("2021-01-02T12:08:15.453616Z"),
                    Sender = "Bob",
                    Receiver = "George",
                    EventType = EventType.HighFive,
                    Message = "Bob high-fives George"
                },
                new Event
                {
                    Id = Guid.Parse("9da6c5af-c523-40d2-acee-408dc94c0b2a"),
                    CreatedOn = DateTime.Parse("2021-01-04T17:07:01.453616Z"),
                    Sender = "Kate",
                    Receiver = null,
                    EventType = EventType.Comment,
                    Message = "Everything is awesome!"
                },
            };
        }
    }
}
