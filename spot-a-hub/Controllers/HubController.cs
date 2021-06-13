using Entities.DTO_s.Reponses;
using Entities.DTO_s.Requests;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Contracts;
using System;
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
        public async Task<ActionResult> GetHubByName([FromBody] CreateHubDTO model)
        {
            var getHubByName = await _repositoryManager.Hubb.GetHubbByName(model.Name, trackchanges: false);

            if (getHubByName == null)
            {
                return NotFound(new ApiResponseDTO<string> { Status = "error", Message = $"hub with the name {model.Name} not found" });
            }

            return Ok(new { Status = "success", Data = getHubByName });
        }


        [HttpGet]
        [Route("/api/gethubsbystate")]
        public async Task<ActionResult> GetHubsByState([FromBody] CreateHubDTO model)
        {
            var getHubsByState = await _repositoryManager.Hubb.GetHubbsByState(model.State, trackchanges : false);

            if (getHubsByState == null)
            {
                return NotFound(new ApiResponseDTO<string> { Status = "error", Message = $"hub located in {model.State} not found" });
            }

            return Ok(new { Status = "success", Data = getHubsByState });
        }

        [HttpGet]
        [Route("/api/gethubsbytag")]
        public async Task<ActionResult> GetHubsByTag([FromBody] CreateHubDTO model)
        {
            var getHubsByTag = await _repositoryManager.Hubb.GetHubbsByTag(model.Tags, trackchanges: false);

            if (getHubsByTag == null)
            {
                return NotFound(new ApiResponseDTO<string> { Status = "error", Message = $"hub with the tag(s) {model.Tags} not found" });
            }

            return Ok(new { Status = "success", Data = getHubsByTag });
        }

        [HttpPost]
        [Route("/api/addhub")]
        public async Task<ActionResult> AddHub([FromBody] CreateHubDTO model)
        {

            var getHub = await _repositoryManager.Hubb.GetHubbByNameSpecial(model.Name, trackchanges: false);

            if (getHub == null)
            {
                return Conflict(new ApiResponseDTO<string> { Status = "error", Message = $"{model.Tags} already exists" });
            }

            return Ok(await AddNewHub(model));

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
    }
}
