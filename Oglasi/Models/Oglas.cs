using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oglasi.Models
{
    public class Oglas
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Полето марка е задолжително")]
        public string Marka { get; set; }
        [Required(ErrorMessage = "Полето модел е задолжително")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Полето наслов е задолжително")]
        public string Nasolv { get; set; }
        [Required(ErrorMessage = "Полето година е задолжително")]
        [Range (1980,2022,ErrorMessage ="Годината мора да биде помеѓу 1980 и 2022")]
        public int Godina { get; set; }
        [Required(ErrorMessage = "Полето цена е задолжително")]
        [Range(200,5000000,ErrorMessage ="Цената мора да биде помеѓу 200 и 5000000 евра")]
        public int Cena { get; set; }
        [Required(ErrorMessage = "Полето боја е задолжително")]
        public string Boja { get; set; }
        public string Opis { get; set; }
        public byte[] Images { get; set; }
        [Required(ErrorMessage ="Полето сопственик е задолжително")]
        public string ime { get; set; }
        [Required(ErrorMessage ="Полето телефон е задолжително")]
        [RegularExpression(@"07[01245678]\d{6}",ErrorMessage ="Невалиден формат на телефонскиот број")]
        public string telefon { get; set; }
        public string userEmail { get; set; }
    }
}