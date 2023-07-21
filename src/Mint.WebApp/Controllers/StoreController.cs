//using Microsoft.AspNetCore.Mvc;
//using Mint.Domain.Common;
//using Mint.Infrastructure.Repositories.Interfaces;
//using Mint.WebApp.Attributes;
//using System.Text.Json;

//namespace Mint.WebApp.Controllers;

//[ApiController]
//[Route("[controller]/[action]")]
//[Authorize(Roles = $"{Constants.ADMIN},{Constants.SELLER},{Constants.BUYER}")]
//public class StoreController : ControllerBase
//{
//    private readonly IStoreRepository _store;

//    public StoreController(IStoreRepository store)
//    {
//        _store = store;
//    }

//    [HttpGet]
//    [AllowAnonymous]
//    public async Task<IActionResult> GetStores()
//    {
//        try
//        {
//            var stores = await _store.GetStoresAsync();
//            return Ok(stores);
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(new { ex.Message });
//        }
//    }

//    [HttpGet("{id}")]
//    public async Task<IActionResult> GetMyStore(Guid id)
//    {
//        try
//        {
//            var store = await _store.GetMyStoreAsync(id);
//            return Ok(store);
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(new { message = ex.Message });
//        }
//    }

//    [HttpPost]
//    public async Task<IActionResult> CreateStore([FromForm] StoreFullBindingModel model)
//    {
//        var y = Request.Form["categories"].ToString().Trim('{', '}');
//        var x = JsonSerializer.Deserialize<CategoryOnlyBindingModel>(y);
//        try
//        {
//            var store = await _store.CreateStoreAsync(model);
//            return Ok(store);
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(new { message = ex.Message });
//        }
//    }
//}
