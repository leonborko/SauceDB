﻿using DataAccess.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Migrations.Migrations
{
    public class CreatePerson : DBMigration
    {
        public override Type AddTable()
        {
            return typeof(Person);
        }
    }
}
