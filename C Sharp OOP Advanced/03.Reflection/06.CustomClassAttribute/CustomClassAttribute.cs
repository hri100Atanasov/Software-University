using System;
using System.Collections.Generic;
using System.Text;

namespace _06.CustomClassAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    class CustomClassAttribute : Attribute
    {
        public CustomClassAttribute(string author, int revision, string description, params string[] reviewers)
        {
            Author = author;
            Revision = revision;
            Description = description;
            Reviewers = reviewers;
        }

        public string Author { get; set; }
        public int Revision { get; set; }
        public string Description { get; set; }
        public string[] Reviewers { get; set; }
    }
}
