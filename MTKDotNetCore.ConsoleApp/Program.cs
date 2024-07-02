#region using

using MTKDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

#endregion

Console.WriteLine("Hello, World!");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
adoDotNetExample.Create("testing_title","testing_author","testing_content");


Console.ReadKey();
