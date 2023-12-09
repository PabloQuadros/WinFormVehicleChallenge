using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormVehicleChallenge.Entities.DomainEntities;
using WinFormVehicleChallenge.Entities.DTOs;

namespace WinFormVehicleChallenge.Services;

public class ModelService
{
    public async Task<List<Model>> GetModelsByBrandCodeParallelum(string code)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"https://parallelum.com.br/fipe/api/v1/carros/marcas/{code}/modelos";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Erro ao buscar os modelos na API da Parallelum.");
                }

                string content = await response.Content.ReadAsStringAsync();
                List<ModelApiDto> modelApiList = JsonConvert.DeserializeObject<List<ModelApiDto>>(content);

                List<Model> models = modelApiList.Select(apiBrand => new Model
                {
                    Code = apiBrand.Codigo,
                    Name = apiBrand.Nome
                }).ToList();

                return models;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
