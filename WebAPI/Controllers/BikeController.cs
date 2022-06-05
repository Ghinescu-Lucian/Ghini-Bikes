using Application.Products.Bikes.Commands.CreateBikeCommand;
using Application.Products.Bikes.Commands.DeleteBikeCommand;
using Application.Products.Bikes.Commands.UpdateBikeCommand;
using Application.Products.Bikes.Queries.GetAllBikes;
using Application.Products.Bikes.Queries.GetBikeById;
using AutoMapper;
using Domain.Models;
using Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public BikeController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        //  [DisableFormValueModelBinding]
        [Route("addBike")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        // [FromForm]
        public async Task<IActionResult> CreateBike([FromForm] BikeDto bike)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Image> images = new List<Image>();

            if (bike.ImagesURL != null)
            {

                for (int i = 0; i < bike.ImagesURL.Count; i++)
                {
                    Image img = new Image
                    {
                        Path = await UploadImage(bike.ImagesURL[i].FileName, bike.ImagesURL[i]),
                        position = i
                    };
                    images.Add(img);
                }

                bike.Images = images;

            }

            var command = _mapper.Map<CreateBikeCommand>(bike);
            var created = await _mediator.Send(command);

            //   return Ok(created);
            return CreatedAtAction(nameof(GetBikeByID), new { bikeId = created.ProductId }, bike);
        }
        [HttpGet]
        [Route("{bikeId}")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Client,Administrator")]
        public async Task<IActionResult> GetBikeByID(int bikeId)
        {
            var query = new GetBikeByIdQuery { Id = bikeId };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound(result);

            foreach (var img in result.Images)
                img.Path = "https://localhost:7155/Images/" + img.Path;

            return Ok(result);

        }

        [HttpDelete]
        [Route("{bikeId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteBike(int bikeId)
        {
            var command = new DeleteBikeCommand { Id = bikeId };
            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound(result);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBikes()
        {
            var query = new GetAllBikesQuery();
            var result = await _mediator.Send(query);
            foreach (var item in result)
                foreach (var img in item.Images)
                    img.Path = "https://localhost:7155/Images/" + img.Path;

            return Ok(result);

        }

        [HttpPut]
        [Route("{bikeId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> UpdateBike(int bikeId, BikeUpdateDto update)
        {
            var bike = _mapper.Map<Bike>(update);

            var commnad = new UpdateBikeCommand
            {
                Id = bikeId,
                Manufacturer = bike.Manufacturer,
                Model = bike.Model,
                Description = bike.Description,
                //  Images = bike.Images,
                Quantity = bike.Quantity,
                Price = bike.Price,
                WarrantyMonths = bike.WarrantyMonths,
                Weight = bike.Weight,
                Year = bike.Year,
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

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class DisableFormValueModelBindingAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var formValueProviderFactory = context.ValueProviderFactories
                    .OfType<FormValueProviderFactory>()
                    .FirstOrDefault();
            if (formValueProviderFactory != null)
            {
                context.ValueProviderFactories.Remove(formValueProviderFactory);
            }

            var jqueryFormValueProviderFactory = context.ValueProviderFactories
                .OfType<JQueryFormValueProviderFactory>()
                .FirstOrDefault();
            if (jqueryFormValueProviderFactory != null)
            {
                context.ValueProviderFactories.Remove(jqueryFormValueProviderFactory);
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
