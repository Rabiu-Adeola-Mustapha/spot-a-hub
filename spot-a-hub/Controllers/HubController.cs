using Entities.DTO_s.Reponses;
using Entities.DTO_s.Requests;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace spot_a_hub.Controllers
{
    [ApiController]
    public class HubController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        public HubController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }


        [HttpGet]
        [Route("/api/getallhubs")]
        public ActionResult GetAllHubs()
        {
            var getHubs = _repositoryManager.Hubb.GetHubs(trackChanges: false);

            return Ok(getHubs);
        }


        [HttpGet]
        [Route("/api/gethubbyname")]
        public async Task<ActionResult> GetHubByName(string name)
        {
            var getHubByName = await _repositoryManager.Hubb.GetHubbByName(name, trackchanges: false);

            if (getHubByName == null)
            {
                return NotFound(new ApiResponseDTO<string> { Status = "error", Message = $"hub with the name '{name.ToUpper()}' not found" });
            }

           
            return Ok(new { Status = "success", Data = getHubByName });
        }


        [HttpGet]
        [Route("/api/gethubsbystate")]
        public async Task<ActionResult> GetHubsByState(string state)
        {
            var getHubsByState = await _repositoryManager.Hubb.GetHubbsByState(state, trackchanges : false);

            if (getHubsByState == null)
            {
                return NotFound(new ApiResponseDTO<string> { Status = "error", Message = $"hub located in {state.ToUpper()} not found" });
            }

            var displayHubsInfo = GetHubDetails(getHubsByState);
        
            return Ok(new { Status = "success", Data = displayHubsInfo });
        }

       
        [HttpGet]
        [Route("/api/gethubsbytag")]
        public async Task<ActionResult> GetHubsByTag(string tag)
        {
            var getHubsByTag = await _repositoryManager.Hubb.GetHubbsByTag(tag, trackchanges: false);

            if (getHubsByTag == null)
            {
                return NotFound(new ApiResponseDTO<string> { Status = "error", Message = $"hub with the tag(s) {tag.ToUpper()} not found" });
            }

            var displayHubsInfo = GetHubDetails(getHubsByTag);

            return Ok(new { Status = "success", Data = displayHubsInfo });
        }

        [HttpPost]
        [Route("/api/addhub")]
        public async Task<ActionResult> AddHub([FromBody] CreateHubDTO model)
        {

            var getHub = await _repositoryManager.Hubb.CheckIfHubExistsByName(model.Name, trackchanges: false);

            if (getHub != null)
            {
                return Conflict(new ApiResponseDTO<string> { Status = "error", Message = $"{model.Name.ToUpper()} already exists" });
            }
            await AddNewHub(model);

            return Ok(new { Status = "success", Message= "Hub has been added sucessfully" });

        }

        private async Task<Hubb> AddNewHub(CreateHubDTO model)
        {
            var hub = new Hubb
            {
                Name = model.Name,
                Address = model.Address,
                State = model.State,
                Image = model.Image,
                Tags = model.Tags,
                Website = model.Website
            };

             _repositoryManager.Hubb.CreateHubb(hub);

            await _repositoryManager.SaveAsync();

            return hub;

        }

        private List<CreateHubDTO> GetHubDetails(IEnumerable<Hubb> getHubsInfo)
        {
            List<CreateHubDTO> getHubs = new List<CreateHubDTO>();

            foreach (var item in getHubsInfo)
            {
                var hubs = new CreateHubDTO
                {
                    Address = item.Address,
                    Image = item.Image,
                    Name = item.Name,
                    State = item.State,
                    Tags = item.Tags,
                    Website = item.Website
                };

                getHubs.Add(hubs);
            }

            return getHubs;
        }

    }
}
