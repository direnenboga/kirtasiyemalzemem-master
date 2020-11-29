using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Threading.Tasks;

namespace kırtasiyemalzemem.Models
{
   
    public class Order
    {
        public Order()
        {
            this.OrderTime = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime OrderTime { get; set; }
    }
    public class Category
    {

       [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class Product
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double price { get; set; }
        public double quantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    [Table("AspNetUsers")]
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string username { get; set; }
        
        public int identityNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        [Required]
        public string RePassword { get; set; }


   

    }

    public class LoginModel
    {
     
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }


    //public class Users
    //{
    //    public Users()
    //    {
    //        this.CreateTime = DateTime.Now;
    //    }
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string UserName { get; set; }
    //    public string Password { get; set; }
    //    public DateTime CreateTime { get; set; }
    //}



}
