﻿using AbstractAccountApi;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisaApi
{
    public class Student
    {
        private string classGroup;
        private string name;
        private string firstname;
        private DateTime dateOfBirth;
        private string wisaID;
        private string stemID;
        private GenderType gender;
        private string stateID;
        private string placeOfBirth;
        private string nationality;
        private string street;
        private string houseNumber;
        private string houseNumberAdd;
        private string postalCode;
        private string city;
        private DateTime classChange;

        public Student(string data, int schoolID)
        {
            string[] values = data.Split(',');
            classGroup = values[0];
            name = values[1];
            firstname = values[2];
            dateOfBirth = DateTime.ParseExact(values[3], "d/M/yyyy", CultureInfo.InvariantCulture);
            wisaID = values[4];
            stemID = values[5];
            gender = values[6].Equals("M") ? GenderType.Male : GenderType.Female;
            stateID = values[7];
            placeOfBirth = values[8];
            nationality = values[9];
            street = values[10];
            houseNumber = values[11];
            houseNumberAdd = values[12];
            postalCode = values[13];
            city = values[14];
            classChange = DateTime.ParseExact(values[15], "d/M/yyyy", CultureInfo.InvariantCulture);
            SchoolID = schoolID;
        }

        /// <summary>
        /// The student's class
        /// </summary>
        public string ClassGroup { get => classGroup; }

        /// <summary>
        /// The student's family name
        /// </summary>
        public string Name { get => name; }

        /// <summary>
        /// The student's first name
        /// </summary>
        public string FirstName { get => firstname; }

        /// <summary>
        /// The student's date of birth
        /// </summary>
        public DateTime DateOfBirth { get => dateOfBirth; }

        /// <summary>
        /// The student's ID according to Wisa
        /// </summary>
        public string WisaID { get => wisaID; }

        /// <summary>
        /// The student's 'stamboeknummer'
        /// </summary>
        public string StemID { get => stemID; } // stamboeknummer

        /// <summary>
        /// The student's Gender
        /// </summary>
        public GenderType Gender { get => gender; }

        /// <summary>
        /// The student's State ID (rijksregister)
        /// </summary>
        public string StateID { get => stateID; } // rijksregisternummer

        /// <summary>
        /// City where this student is born
        /// </summary>
        public string PlaceOfBirth { get => placeOfBirth; }

        /// <summary>
        /// Student's nationality
        /// </summary>
        public string Nationality { get => nationality; }

        /// <summary>
        /// The street where this student lives
        /// </summary>
        public string Street { get => street; }

        /// <summary>
        /// The house number of the street where this student lives
        /// </summary>
        public string HouseNumber { get => houseNumber; }

        /// <summary>
        /// Add this to the house number (could be bus number)
        /// </summary>
        public string HouseNumberAdd { get => houseNumberAdd; }

        /// <summary>
        /// The postal code of the student's address
        /// </summary>
        public string PostalCode { get => postalCode; }

        /// <summary>
        /// The city where the student lives
        /// </summary>
        public string City { get => city; }

        /// <summary>
        /// The official date of the student's most recent class change
        /// </summary>
        public DateTime ClassChange { get => classChange; }

        /// <summary>
        /// The ID of the school this student belongs to
        /// </summary>
        public int SchoolID { get; }

        public JObject ToJson()
        {
            JObject result = new JObject();
            result["ClassGroup"] = ClassGroup;
            result["Name"] = Name;
            result["FirstName"] = FirstName;
            result["DateOfBirth"] = Utils.DateToString(DateOfBirth);
            result["WisaID"] = WisaID;
            result["StemID"] = StemID;
            result["Gender"] = Gender.ToString();
            result["StateID"] = StateID;
            result["PlaceOfBirth"] = PlaceOfBirth;
            result["Nationality"] = Nationality;
            result["Street"] = Street;
            result["HouseNumber"] = HouseNumber;
            result["HouseNumberAdd"] = HouseNumberAdd;
            result["PostalCode"] = PostalCode;
            result["City"] = City;
            result["ClassChange"] = Utils.DateToString(ClassChange);
            result["SchoolID"] = SchoolID;
            return result;
        }

        public Student(JObject obj)
        {
            classGroup = obj["ClassGroup"].ToString();
            name = obj["Name"].ToString();
            firstname = obj["FirstName"].ToString();
            dateOfBirth = Utils.StringToDate(obj["DateOfBirth"].ToString());
            wisaID = obj["WisaID"].ToString();
            stemID = obj["StemID"].ToString();
            string gType = obj["Gender"].ToString();
            switch (gType)
            {
                case "Male": gender = GenderType.Male; break;
                case "Female": gender = GenderType.Female; break;
                case "Transgender": gender = GenderType.Transgender; break;
            }
            stateID = obj["StateID"].ToString();
            placeOfBirth = obj["PlaceOfBirth"].ToString();
            nationality = obj["Nationality"].ToString();
            street = obj["Street"].ToString();
            houseNumber = obj["HouseNumber"].ToString();
            houseNumberAdd = obj["HouseNumberAdd"].ToString();
            postalCode = obj["PostalCode"].ToString();
            city = obj["City"].ToString();
            classChange = Utils.StringToDate(obj["ClassChange"].ToString());
            SchoolID = Convert.ToInt32(obj["SchoolID"]);
        }
    }
}
