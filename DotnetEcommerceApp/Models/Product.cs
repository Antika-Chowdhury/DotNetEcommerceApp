using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetEcommerceApp.Models;

public class Product
{
    [Key]  // Marks Id as the primary key
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
    public int Id {get;set;}
    public required  string Name {get;set;}
    public int Price {get;set;}
    public int Stock {get;set;}
}
