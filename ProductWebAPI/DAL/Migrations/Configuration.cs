﻿namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.PContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.PContext context)
        {
            /*Random rand = new Random();
            for (int i = 1; i <= 1000; i++)
            {
                context.Products.Add(
                    new EF.TableModels.Product()
                    {
                        Name = Guid.NewGuid().ToString(),
                        PId = rand.Next(1, 6),
                    }
                 );
            }*/
        }
    }
}
