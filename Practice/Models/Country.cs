using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Practice.Models
{

    public class CountryCode
    {
        public string number { get; set; }
        public Countries Countries { get; set; }
    }
    public class Countries
    {
       
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string CountryIso { get; set; }

        public List<CountryDetail> countryDetails { get; set; }

        //public List<CountryDetails> countryDetails { get; set; }
    }
    public class CountryDetail
    {
     
        public string Operator { get; set; }
        public string OperatorCode { get; set; }

    }

    public class Country
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string CountryIso { get; set; }
       
        public List<CountryDetails> countryDetails { get; set; }

        //public List<CountryDetails> countryDetails { get; set; }
    }

    public class CountryDetails
    {
        public int Id { get; set; }

        //public virtual Country Country { get; set; }
        public int CountryId { get; set; }
        public string Operator { get; set; }
        public string OperatorCode { get; set; }
       
    }

    public class DbInitializer
    {
        public static void Seed(ApiDBContext context)
        {

            if (!context.Country.Any())
            {
                context.Country.AddRange(
                    new Country
                    {
                        Id = 1,
                        CountryCode = "234",
                        Name = "Nigeria",
                        CountryIso = "NG",
                        countryDetails=new List<CountryDetails>()
                        { new CountryDetails { Id = 1, CountryId = 1, Operator = "MTN Nigeria", OperatorCode = "MTN NG" },
                         new CountryDetails { Id = 2, CountryId = 1, Operator = "Airtel Nigeria", OperatorCode = "ANG" },
               new CountryDetails { Id = 3, CountryId = 1, Operator = "9 Mobile Nigeria", OperatorCode = "MTN NG" },
                new CountryDetails { Id = 4, CountryId = 1, Operator = "Globacom Nigeria", OperatorCode = "GLO NG" },}
                    },

                     new Country
                     {
                         Id = 2,
                         CountryCode = "233",
                         Name = "Ghana",
                         CountryIso = "GN",
                         countryDetails = new List<CountryDetails>()
                         {new CountryDetails { Id = 5, CountryId = 2, Operator = "Vodafone Ghana", OperatorCode = "Vodafone GH" },
               new CountryDetails { Id = 6, CountryId = 2, Operator = "MTN Ghana ", OperatorCode = "MTN Ghana" },
               new CountryDetails { Id = 7, CountryId = 2, Operator = "Tigo Ghana", OperatorCode = "Tigo Ghana" }, }
                     },
                  new Country
                  {
                      Id = 3,
                      CountryCode = "229",
                      Name = "Benin Republic",
                      CountryIso = "BN",
                      countryDetails = new List<CountryDetails>()
                      { new CountryDetails { Id = 8, CountryId = 3, Operator = "MTN Benin", OperatorCode = "MTN Benin" },
                new CountryDetails { Id = 9, CountryId = 3, Operator = "Moov Benin", OperatorCode = "Moov Benin" }, }
                  },
                 new Country
                 {
                     Id = 4,
                     CountryCode = "225",
                     Name = "Côte d'Ivoire",
                     CountryIso = "CIV",
                     countryDetails = new List<CountryDetails>()
                     {new CountryDetails { Id = 10, CountryId = 4, Operator = "MTN Côte d'Ivoire", OperatorCode = "MTN CIV" } }
                 }

                    );
            }

            context.SaveChanges();
            //if (!context.CountryDetails.Any())
            //{
            //    context.AddRange
            //    (
            //        new CountryDetails { Id = 1, CountryId = 1, Operator = "MTN Nigeria", OperatorCode = "MTN NG" },
            //     new CountryDetails { Id = 2, CountryId = 1, Operator = "Airtel Nigeria", OperatorCode = "ANG" },
            //   new CountryDetails { Id = 3, CountryId = 1, Operator = "9 Mobile Nigeria", OperatorCode = "MTN NG" },
            //    new CountryDetails { Id = 4, CountryId = 1, Operator = "Globacom Nigeria", OperatorCode = "GLO NG" },
            //  new CountryDetails { Id = 5, CountryId = 2, Operator = "Vodafone Ghana", OperatorCode = "Vodafone GH" },
            //   new CountryDetails { Id = 6, CountryId = 2, Operator = "MTN Ghana ", OperatorCode = "MTN Ghana" },
            //   new CountryDetails { Id = 7, CountryId = 2, Operator = "Tigo Ghana", OperatorCode = "Tigo Ghana" },
            //    new CountryDetails { Id = 8, CountryId = 3, Operator = "MTN Benin", OperatorCode = "MTN Benin" },
            //    new CountryDetails { Id = 9, CountryId = 3, Operator = "Moov Benin", OperatorCode = "Moov Benin" },
            //     new CountryDetails { Id = 10, CountryId = 4, Operator = "MTN Côte d'Ivoire", OperatorCode = "MTN CIV" });

            //};

            //context.SaveChanges();
        }
    }

}
