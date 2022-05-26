using Application.Products.Accessories.Commands.CreateAccessoryCommand;
using Application.Products.Accessories.Commands.DeleteAccessoryCommand;
using Application.Products.Accessories.Commands.UpdateAccessoryCommand;
using Application.Products.Accessories.Queries.GetAccessoryById;
using Application.Products.Accessories.Queries.GetAllAccessories;
using AutoMapper;
using Domain.Models;
using Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AccessoryController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("addAccessory")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> CreateAccessory([FromForm] AccessoryDto acc)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            List<Image> images = new List<Image>();

            if (acc.ImagesURL != null)
            {

                for (int i = 0; i < acc.ImagesURL.Count; i++)
                {
                    Image img = new Image
                    {
                        Path = await UploadImage(acc.ImagesURL[i].FileName, acc.ImagesURL[i]),
                        position = i
                    };
                    images.Add(img);
                }

                acc.Images = images;

            }

            var command = _mapper.Map<CreateAccessoryCommand>(acc);
            var created = await _mediator.Send(command);

            //   return Ok(created);
            return CreatedAtAction(nameof(GetAccessoryByID), new { accessoryId = created.ProductId }, acc);
        } 
        [HttpGet]
        [Route("{accessoryId}")]
        public async Task<IActionResult> GetAccessoryByID(int accessoryId)
        {
            var query = new GetAccessoryByIdQuery { Id = accessoryId };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound(result);
            foreach (var img in result.Images)
                img.Path = "https://localhost:7155/Images/" + img.Path;
            return Ok(result);

        }

        [HttpDelete]
        [Route("{accessoryId}")]
       public async Task<IActionResult> DeleteAccessory(int accessoryId)
        {
            var command = new DeleteAccessoryCommand { Id = accessoryId };
            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound(result);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccessories()
        {
            var query = new GetAllAccessoriesQuery();
            var result = await _mediator.Send(query);
            foreach (var item in result)
                foreach (var img in item.Images)
                    img.Path = "https://localhost:7155/Images/" + img.Path;
            return Ok(result);

        }

        [HttpPut]
        [Route("{accessoryId}")]
        public async Task<IActionResult> UpdateAccessory(int accessoryId, AccessoryDto update)
        {
            var acc = _mapper.Map<Accessory>(update);
            var commnad = new UpdateAccessoryCommand
            {
                Id = accessoryId,
                Manufacturer = acc.Manufacturer,
                Model = acc.Model,
                Description = acc.Description,
                Images = acc.Images,
                Price = acc.Price,
                Year = acc.Year,
                Quantity = acc.Quantity
                
            };
            var result = await _mediator.Send(commnad);
            if (result == null)
                return NotFound();
            return NoContent();
        }
        private async Task<string> UploadImage(string fileName, IFormFile file)
        {
            string folderPath = "C:\\Users\\ghine\\Desktop\\Facultate\\Amdaris\\Proiect\\Ghini-Bike\\Ghini-Bikes\\WebAPI\\Images";
            var new_name = Guid.NewGuid().ToString() + "_" + fileName;
            folderPath = Path.Combine(folderPath, new_name);
            await file.CopyToAsync(new FileStream(folderPath, FileMode.Create));

            return new_name;
        }
    }
}
