using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormVehicleChallenge.Entities.DomainEntities;
using WinFormVehicleChallenge.Entities.DTOs;

namespace WinFormVehicleChallenge.Services;

public class BrandService
{
   
    public async Task<List<Brand>> GetBandsByParallelum()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://parallelum.com.br/fipe/api/v1/carros/marcas";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Erro ao buscar as marcas na API da Parallelum.");
                }

                string content = await response.Content.ReadAsStringAsync();
                List<BrandApiDto> brandApiList = JsonConvert.DeserializeObject<List<BrandApiDto>>(content);

                List<Brand> brands = brandApiList.Select(apiBrand => new Brand
                {
                    Code = apiBrand.Codigo,
                    Name = apiBrand.Nome
                }).ToList();

                return brands;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
  
    }
}
