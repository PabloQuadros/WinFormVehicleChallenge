using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinFormCarChallenge.Entities.DomainEntities;

public class Vehicle
{
    public string Plate { get; set; }
    public string Chassi { get; set; }
    public string BrandId { get; set; }
    public string BrandName { get; set; }
    public string ModelId { get; set; }
    public string ModelName { get; set; }
    public decimal FipeValue { get; set; }
    public decimal SaleValue { get; set;}
    public string Observations { get; set; }


    public void Validate()
    {
        this.Plate = this.ValidatePlate(this.Plate);
        this.Chassi = this.ValidateChassi(this.Chassi);
        this.Observations = this.ValidateObservations(this.Observations);
    }

    public string ValidatePlate(string plate)
    {
        if(!Regex.IsMatch(plate, @"^[A - Z0 - 9]{ 3,7}$| ^[A - Z]{ 2}\d{ 2}[A-Z0 - 9]{ 2,4}$"))
        {
            throw new ArgumentException("A placa informada não está em um formato válido. Formatos válidos: 'ABC123', 'XY45AB', 'AB12CD'.");
        }
        return plate;
    }

    public string ValidateChassi(string chassi)
    {
        if(!Regex.IsMatch(chassi, @"^[A - HJ - NPR - Z0 - 9]{ 17}$"))
        {
            throw new ArgumentException("O campo chassi deve conter apenas letras maiúsculas (exceto I, O, Q) e dígitos, e deve ter exatamente 17 caracteres.");
        }
        return chassi;
    }

    public string ValidateObservations(string observations)
    {
        if(!Regex.IsMatch(observations, @"^[a-zA-Z0-9\-\/.]{1,150}$"))
        {
            throw new ArgumentException("O campo observations deve conter no máximo 150 caracteres alfanuméricos, '-', '/', ou '.'.");
        }
        return observations;
    }
}
