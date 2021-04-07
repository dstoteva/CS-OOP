namespace P03_StudentSystem   
{
    using P03_StudentSystem.Commands;
    using P03_StudentSystem.Students;
    using System;
    class StartUp
    {
        static void Main()
        {
            var commandParser = new CommandParser();
            var studentSystem = new StudentSystem();

            var engine = new Engine(commandParser, studentSystem, () => Console.ReadLine());
            engine.Run();
        }
    }
}
