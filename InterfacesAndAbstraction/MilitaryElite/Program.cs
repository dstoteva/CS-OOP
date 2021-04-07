using MilitaryElite.Models;
using MilitaryElite.Models.Privates;
using MilitaryElite.Models.Privates.SpecialisedSoldiers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Private> privates = new List<Private>();
            while (true)
            {
                try
                {
                    string[] soldierArgs = Console.ReadLine().Split();
                    string type = soldierArgs[0];

                    if (type == "End")
                    {
                        break;
                    }
                    string id = soldierArgs[1];
                    string firstName = soldierArgs[2];
                    string lastName = soldierArgs[3];

                    if (type == "Spy")
                    {
                        int codeNumber = int.Parse(soldierArgs[4]);
                        var spy = new Spy(id, firstName, lastName, codeNumber);
                        Console.WriteLine(spy);
                    }
                    else
                    {
                        decimal salary = decimal.Parse(soldierArgs[4]);
                        if (type == "Private")
                        {
                            var @private = new Private(id, firstName, lastName, salary);
                            privates.Add(@private);
                            Console.WriteLine(@private);
                        }
                        else if (type == "LieutenantGeneral")
                        {
                            var privatesGeneral = new List<Private>();
                            for (int i = 5; i < soldierArgs.Length; i++)
                            {
                                var currentPrivate = privates.FirstOrDefault(x => x.Id == soldierArgs[i]);
                                privatesGeneral.Add(currentPrivate);
                            }
                            var leutenant = new LieutenantGeneral(id, firstName, lastName, salary, privatesGeneral);
                            Console.WriteLine(leutenant);
                        }
                        else if (type == "Engineer")
                        {
                            var repairs = new List<Repair>();
                            string corps = soldierArgs[5];
                            for (int i = 6; i < soldierArgs.Length; i += 2)
                            {
                                string name = soldierArgs[i];
                                int hours = int.Parse(soldierArgs[i + 1]);
                                var repair = new Repair(name, hours);
                                repairs.Add(repair);
                            }
                            var engineer = new Engineer(id, firstName, lastName, salary, corps, repairs);
                            Console.WriteLine(engineer);

                        }
                        else if (type == "Commando")
                        {
                            var missions = new List<Mission>();
                            string corps = soldierArgs[5];

                            for (int i = 6; i < soldierArgs.Length; i += 2)
                            {
                                try
                                {
                                    string name = soldierArgs[i];
                                    string state = soldierArgs[i + 1];
                                    var mission = new Mission(name, state);
                                    missions.Add(mission);
                                }
                                catch (Exception)
                                {
                                }

                            }
                            var commando = new Commando(id, firstName, lastName, salary, corps, missions);
                            Console.WriteLine(commando);
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
