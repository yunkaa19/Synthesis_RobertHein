﻿using System.ComponentModel.DataAnnotations;

namespace Models.DTO;

public class Register
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string password { get; set; }

    [Required] public string firstName { get; set; }
    [Required] public string lastName { get; set; }
    [Required] [DataType(DataType.Date)] public string birthdayDate { get; set; }
    
    [Required]
    [DataType(DataType.PostalCode)]
    public string postalCode { get; set; }

    

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string phoneNumber { get; set; }
}