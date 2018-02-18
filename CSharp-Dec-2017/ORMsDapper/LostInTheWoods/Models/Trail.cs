using System;
using System.ComponentModel.DataAnnotations;

namespace LostInTheWoods.Models
{
    public abstract class BaseEntity {}
    public class Trail : BaseEntity
    {
        private const string LatRegex = "^(\\+|-)?(?:90(?:(?:\\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\\.[0-9]{1,6})?))$"; 
        private const string LongRegex = "^(\\+|-)?(?:180(?:(?:\\.0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\\.[0-9]{1,6})?))$";
        [Key]
        public int Id {get;set;}
        [Display(Name="Trail Name:")]
        [Required(ErrorMessage="Trail Name is required.")]
        public string Name {get;set;}
        [Display(Name="Description:")]
        [Required(ErrorMessage="Description is required.")]
        [MinLength(10, ErrorMessage="Description must be 10 or more characters.")]
        public string Description {get;set;}
        [Display(Name="Length:")]
        [Required(ErrorMessage="Length is required.")]
        public double Length {get;set;}
        [Display(Name="Elevation Change:")]
        [Required(ErrorMessage="Elevation Change is required.")]
        public int Elevation {get;set;}
        [Display(Name="Longitude:")]
        [Required(ErrorMessage="Longitude is required.")]
        [RegularExpression(LongRegex, ErrorMessage="Invalid Longitude value")]
        public double Longitude {get;set;}
        [Display(Name="Latitude:")]
        [Required(ErrorMessage="Latitude is required.")]
        [RegularExpression(LatRegex, ErrorMessage="Invalid Latitude value")]
        public double Latitude {get;set;}
    }
}