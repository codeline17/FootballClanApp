﻿using System;
using System.Collections.Generic;

namespace Objects
{
    public class Chatroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Chatmessage> Messages { get; set; }

        public Chatroom(int id, string name)
        {
            Id = id;
            Name = name;
            Messages = new List<Chatmessage>();
        }
    }

    public class Chatmessage
    {
        public string Message { get; set; }
        public string From { get; set; }
        private DateTime _datetime { get; set; }
        public bool Disposable { get; set; }
        public string TimeStamp
            => _datetime.Date != DateTime.Now.Date ? _datetime.ToString("dd/MM hh:mm") : _datetime.ToString("hh:mm");

        public Chatmessage(string message, string from, DateTime datetime, bool disposable)
        {
            Message = message;
            From = from;
            _datetime = datetime;
            Disposable = disposable;
        }
    }
}
