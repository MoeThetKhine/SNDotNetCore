﻿#region AdoDotNetExample

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("testing_title","testing_author","testing_content");
//adoDotNetExample.Update(1, "title edited", "author edited", "content edited");
//adoDotNetExample.Update(200, "title edited", "author edited", "content edited");
//adoDotNetExample.Delete(10011);
//adoDotNetExample.Edit(100);

#endregion

#region DapperExample

//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

#endregion

#region Program

public class Program
{
    private static void Main(string[] args)
    {
        EFCoreExample eFCoreExample = new();
        eFCoreExample.Run();

        Console.ReadKey();
    }
}

#endregion