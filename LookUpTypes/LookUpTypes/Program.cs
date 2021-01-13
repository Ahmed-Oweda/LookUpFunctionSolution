using System;
using System.Collections.Generic;

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
            ,} ;

            List<LookUp> lastLookUpCombination = new List<LookUp>() {
                new LookUp(1,"H1","Hospital2",firstlookup),
               
                //new LookUp(4,"C1","Clinic2",secondlookup),

                new LookUp(11,"D2","Doctor1",thirdlookup)
                
            ,};



            //List<string> LookUpTypesList = new List<string> { "Hospitals", "Clinics", "Doctors" };
            //List<string> allLookUpList = new List<string> { "Hospital1", "Hospital2", "Hospital3", "Clinics1", "Clinics2", "Clinics3" , "Doctors1" , "Doctors2" ,  "Doctors3" };

            PodFeature feature = new PodFeature(1, "GetAppointments");
            feature.LookUpTypes = lookuptypesList;


            var result = MakeCombinationsOfLookUps(feature, lookupsList,lastLookUpCombination);


           

        }

        public static List<LookUp> MakeCombinationsOfLookUps( PodFeature feature, List<LookUp> LookUpList , List<LookUp> lastLookUpCombination = null)
        {
            //filter the LookUps List here according to the feature Lookup types
            // function filter ()

            //List<string> hospitals = new List<string> { "Hospital1", "Hospital2", "Hospital3" };
            //List<string> clinics = new List<string> { "Clinic1", "Clinic2", "Clinic3" };
            //List<string> doctors = new List<string> { "doctor1", "doctor2", "doctor3" };

            //List<List<string>> LookUpTypesSeperated = new List<List<string>> { hospitals, clinics, doctors };
            // return new list of lookups seperatly 

            var filteredList = new List<List<LookUp>>() { };
            
            LookUpType previousType = new LookUpType();

            for (int i = 0; i < LookUpList.Count; i++)
            {
                LookUpType currentType = LookUpList[i].Lookuptype;

                if (currentType.Name == previousType.Name)
                {
                    previousType = currentType;
                    continue;
                }
                else
                {
                    var matchedItemsOfTheSameLookUpTypes = LookUpList.FindAll(lookup => lookup.Lookuptype.Name == currentType.Name);
                    var tempList = new List<LookUp>(matchedItemsOfTheSameLookUpTypes);

                    if(!filteredList.Contains(tempList) && feature.LookUpTypes.Exists(t => t.Name == currentType.Name))
                    {
                        filteredList.Add(tempList);
                        previousType = currentType;
                    }

                    

                    previousType = currentType;
                    
                }


            }



            var result = new List<LookUp>() { };
            if (lastLookUpCombination == null)
            {
                //this is the first combination


                for (int i = 0; i < filteredList.Count; i++)
                {
                    result.Add(filteredList[i][0]);
                }

               
                return result;

            }
            else
            {
               

              

                for (int i = 0; i < filteredList.Count; i++)
                {
                    int usedLookUpIndex = filteredList[i].FindIndex(t => t.Name == lastLookUpCombination[i].Name);
                    try
                    {
                        result.Add(filteredList[i][usedLookUpIndex + 1]);
                    }
                    catch (Exception)
                    {

                        result.Add(filteredList[i][0]);
                    }
                }

                return result;
            }
        }
    }
}
