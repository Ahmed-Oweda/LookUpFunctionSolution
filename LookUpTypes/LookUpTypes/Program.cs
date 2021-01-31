using System;
using System.Collections.Generic;
using System.Linq;

namespace LookUpTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            LookUpType firstlookup = new LookUpType(1, "Hospitals");
            LookUpType secondlookup = new LookUpType(2, "Clinics");
            LookUpType thirdlookup = new LookUpType(3, "Doctors");
            LookUpType fourthlookup = new LookUpType(4, "Rooms");


            List<LookUpType> lookuptypesList = new List<LookUpType>() {
                firstlookup,
                secondlookup,
                thirdlookup
            };

            List<LookUp> lookupsList = new List<LookUp>() {
                new LookUp(1,"H1","Hospital1",firstlookup),
                new LookUp(2,"H2","Hospital2",firstlookup),
                new LookUp(3,"H3","Hospital3",firstlookup),
                new LookUp(4,"C1","Clinic1",secondlookup),
                new LookUp(5,"C2","Clinic2",secondlookup),
                new LookUp(6,"C3","Clinic3",secondlookup),
                new LookUp(7,"R1","Room1",fourthlookup),
                new LookUp(8,"R2","Room2",fourthlookup),
                new LookUp(9,"R3","Room3",fourthlookup),
                new LookUp(10,"D1","Doctor1",thirdlookup),
                new LookUp(11,"D2","Doctor2",thirdlookup),
                new LookUp(12,"D3","Doctor3",thirdlookup)
            ,};

            List<LookUp> lastLookUpCombination = new List<LookUp>() {
                new LookUp(2,"H2","Hospital2",firstlookup),

               new LookUp(6,"C3","Clinic3",secondlookup),

                new LookUp(10,"D1","Doctor1",thirdlookup)


            ,};



            //List<string> LookUpTypesList = new List<string> { "Hospitals", "Clinics", "Doctors" };
            //List<string> allLookUpList = new List<string> { "Hospital1", "Hospital2", "Hospital3", "Clinics1", "Clinics2", "Clinics3" , "Doctors1" , "Doctors2" ,  "Doctors3" };

            PodFeature feature = new PodFeature(1, "GetAppointments");
            feature.LookUpTypes = lookuptypesList;


            var result = MakeCombinationsOfLookUps(lookupsList, lookuptypesList, lastLookUpCombination);


            Console.ReadKey();

        }

        private static bool RecursiveLookUps(List<LookUp> lookUpList,
            List<LookUp> generateList, List<LookUp> lastLookUpCombination, List<LookUpType> lookUpTypes, LookUpType lookUpType)
        {
            var added = false;

            if (lookUpType == null)
            {
                lookUpType = lookUpTypes.FirstOrDefault();

            }

            if (lookUpType != null)
            {
                var currentLookup = lastLookUpCombination.FirstOrDefault(t => t.Lookuptype.Id == lookUpType.Id);

                if (!lookUpTypes.Any(t => t.Id > lookUpType.Id))
                {
                    currentLookup = SetCurrentLookup(lookUpList, lookUpType, currentLookup, ref added);
                }
                else
                {
                    if (currentLookup == null)
                    {
                        currentLookup = lookUpList.FirstOrDefault(t =>
                            t.Lookuptype.Id == lookUpType.Id);
                    }
                    added = RecursiveLookUps(lookUpList, generateList, lastLookUpCombination,
                        lookUpTypes, lookUpTypes.FirstOrDefault(t => t.Id > lookUpType.Id));

                    if (added)
                    {
                        currentLookup = SetCurrentLookup(lookUpList, lookUpType, currentLookup, ref added);
                    }
                }

                if (currentLookup != null)
                {
                    generateList.Add(currentLookup);
                }

            }




            return added;
        }

        private static LookUp SetCurrentLookup(List<LookUp> lookUpList, LookUpType lookUpType, LookUp currentLookup, ref bool added)
        {
            if (currentLookup != null)
            {
                if (lookUpList.Any(t => t.Lookuptype.Id == lookUpType.Id && t.Id > currentLookup.Id))
                {
                    currentLookup = lookUpList.FirstOrDefault(t =>
                        t.Lookuptype.Id == lookUpType.Id && t.Id > currentLookup.Id);
                    added = false;
                }
                else
                {
                    currentLookup = lookUpList.FirstOrDefault(t =>
                        t.Lookuptype.Id == lookUpType.Id);

                    added = true;
                }
            }
            else
            {
                currentLookup = lookUpList.FirstOrDefault(t =>
                    t.Lookuptype.Id == lookUpType.Id);
            }

            return currentLookup;
        }

        public static List<LookUp> MakeCombinationsOfLookUps(List<LookUp> lookUpList, List<LookUpType> lookupTypesList, List<LookUp> lastLookUpCombination = null)
        {
            var output = new List<LookUp>();

            RecursiveLookUps(lookUpList, output, lastLookUpCombination, lookupTypesList, null);

            return output;
        }


    }
}
