﻿using static System.Console;

WriteLine(".:: M31.FluentApi ::.");

var person = CreatePerson.WithFirstName("Fábio");

WriteLine(person.GetFullName());