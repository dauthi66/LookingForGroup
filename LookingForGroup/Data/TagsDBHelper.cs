﻿using LookingForGroup.Areas.Identity.Data;
using System.Linq;

namespace LookingForGroup.Data
{
    internal partial class TagDBHelper
    {
        public static void addTag(string newTag)
        {
            using LookingForGroupDbContext database = new();
            Tags? tag = (from Tags in database.Tags
                         where Tags.TagName == newTag
                         select Tags).FirstOrDefault();

            if (tag is null)
            {
                Tags tags = new()
                {
                    TagName = newTag
                };
                database.Tags.Add(tags);
                database.SaveChanges();
            }
        }
    }
}