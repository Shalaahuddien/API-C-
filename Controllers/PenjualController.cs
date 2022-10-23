using Microsoft.AspNetCore.Mvc;
using Mendata.Net.Datas.Entities;
using Mendata.Api.Net.Datas;


namespace Mendata.Net.Controllers;

[ApiController]
[Route("[controller]")]

public class PenjualController : ControllerBase
{
    private readonly IRepository<Penjual> _dbcontext;

    public PenjualController(IRepository<Penjual> dbcontext)
    {
        _dbcontext = dbcontext;
    }

    [HttpGet]
    public IActionResult Penjual()
    {
        var penjual = _dbcontext.GetList();
        return Ok(penjual);
    }
    [HttpPost]
    public IActionResult InputPenjual(RequestPenjual req)
    {
        var penjual = new Penjual()
        {
            NamaToko = req.NamaToko,
            Alamat = req.Alamat,
            IdUser = req.IdUser
        };

        _dbcontext.Add(penjual);
        return Created("", penjual);
    }
    [HttpGet("{id}")]
    public IActionResult DetailPenjual(int id)
    {
        var penjual = _dbcontext.Get(id);
        return Ok(penjual);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePenjual(int id, RequestPenjual req)
    {
        var penjual = _dbcontext.Get(id);
        if (penjual == null)
        {
            return NotFound();
        };
        penjual.NamaToko = req.NamaToko;
        penjual.Alamat = req.Alamat;
        _dbcontext.Update(penjual);
        return Ok(penjual);
    }
    [HttpDelete("{id}")]
    public IActionResult DeletePenjual(int id)
    {
        var penjual = _dbcontext.Get(id);
        if (penjual == null)
        {
            return NotFound();
        };

        _dbcontext.Remove(id);
        return Ok();
    }


}