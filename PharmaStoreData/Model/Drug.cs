using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace PharmaStoreData
{
    [Table(Name = "Drugs")]
    public class Drug
    {
        [Column(Name = "id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Max lenght 50 symbols")]
        [RegularExpression("[A-Za-z ]+$", ErrorMessage = "This is field for only words")]
        [Column(Name = "name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(50, ErrorMessage = "Max lenght 50 symbols")]
        [RegularExpression("[A-Za-z,. ]+$", ErrorMessage = "This is field for only words")]
        [Column(Name = "description")]
        public string Description { get; set; } 
        
        [Required(ErrorMessage = "Manufacturer is required")]
        [StringLength(50, ErrorMessage = "Max lenght 50 symbols")]
        [RegularExpression("[A-Za-z ]+$", ErrorMessage = "This is field for only words")]
        [Column(Name = "manufacturer")]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(50, ErrorMessage = "Max lenght 20 symbols")]
        [RegularExpression("[A-Za-z ]+$", ErrorMessage = "This is field for only words")]
        [Column(Name = "country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [RegularExpression("^[0-9() ]+$", ErrorMessage = "This is field only numeric")]
        [Range(0, 9999, ErrorMessage = "Please enter real value")]
        [Column(Name = "price")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [RegularExpression("^[0-9() ]+$", ErrorMessage = "This is field only numeric")]
        [Range(0, 9999, ErrorMessage = "Please enter real value")]
        [Column(Name = "amount")]
        public int Amount { get; set; }


        [Required(ErrorMessage = "Manufactured Date is required")]
        [DataType(DataType.DateTime, ErrorMessage = "Example(01.01.2001)")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        [Column(Name = "manufactureddate")]
        public DateTime ManufacturedDate { get; set; }

        [Required(ErrorMessage = "Expiration is required")]
        [Range(1, 500, ErrorMessage = "Please enter real expiration date")]
        [RegularExpression("^[0-9() ]+$", ErrorMessage = "This is field only numeric")]
        [Column(Name = "expiration")]
        public int Expiration { get; set; }     
    }
}
