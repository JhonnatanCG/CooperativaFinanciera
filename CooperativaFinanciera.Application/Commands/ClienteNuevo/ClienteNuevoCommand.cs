﻿using CooperativaFinanciera.Domain;
using CooperativaFinanciera.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CooperativaFinanciera.Application.Commands.ClienteNuevo
{
    public record ClienteNuevoCommand() : IRequest<bool>
    {
        [FromBody]
        [Required]
        [StringLength(2)]
        public string? TipoDocumento { get; set; }

        [Required]
        public long NumeroDocumento { get; set; }

        [Required]
        [StringLength(30)]
        public string? Nombres { get; set; }

        [Required]
        [StringLength(30)]
        public string? Apellido1 { get; set; }

        [StringLength(30)]
        public string? Apellido2 { get; set; }

        [Required]

        public string? Genero { get; set; } // Usando enum en lugar de lista

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string? Email { get; set; }


        public ICollection<Direcciones> Direcciones { get; set; } = new List<Direcciones>();
        public ICollection<Telefono> Telefonos { get; set; } = new List<Telefono>();
    }
}
