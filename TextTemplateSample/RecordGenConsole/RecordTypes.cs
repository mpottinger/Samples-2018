﻿using System;

namespace RecordGenConsole
{
    public partial class Person
    {
        public int Id { get; }
        public string Name { get; }
        public DateTime Birthday { get; }
        public Uri Uri { get; }
        public System.Text.Encoding Encoding { get; }

        public Person(int id, string name, DateTime birthday, Uri uri, System.Text.Encoding encoding)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
            Uri = uri;
            Encoding = encoding;
        }
    }

    public partial class Empty
    {

        public Empty()
        {
        }
    }

    public partial class Number
    {
        public int N { get; }
        public double? Scale { get; }
        public DayOfWeek DayOfWeek { get; }

        public Number(int n, double? scale, DayOfWeek dayOfWeek)
        {
            N = n;
            Scale = scale;
            DayOfWeek = dayOfWeek;
        }
    }

}
