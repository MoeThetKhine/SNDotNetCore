﻿#region using

using MTKDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

#endregion

Console.WriteLine("Hello, World!");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("testing_title","testing_author","testing_content");
adoDotNetExample.Update(1, "title edited", "author edited", "content edited");
adoDotNetExample.Update(200, "title edited", "author edited", "content edited");


Console.ReadKey();
