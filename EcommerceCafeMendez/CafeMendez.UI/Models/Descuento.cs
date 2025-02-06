using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

public class Descuento
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El código es obligatorio")]
    [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
    [Display(Name = "Código")]
    public string DiscountName{ get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
   
    public decimal DiscountPercentage { get; set; }
    [Range(1, 100, ErrorMessage = "El descuento debe ser entre 1% y 100%")]

    [Required(ErrorMessage = "Fecha de inicio obligatoria")]
    [DataType(DataType.Date)]
    [Display(Name = "Inicio")]
    public DateTime StartDate { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Fecha de expiración obligatoria")]
    [DataType(DataType.Date)]
    [Display(Name = "Expiración")]
    public DateTime ExpirationDate { get; set; } = DateTime.Today.AddDays(7);

    [Display(Name = "Activo")]
    public bool IsActive { get; set; } = true;
}