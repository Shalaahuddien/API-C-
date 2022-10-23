using Microsoft.AspNetCore.Mvc;
using Mendata.Net.Datas.Entities;
using Mendata.Net.Datas.Entities.Request;

namespace Mendata.Net.Controllers;

[ApiController]
[Route("[controller]")]

public class BarangController : Controller
{
    private readonly EMarketDbContext _dbcontext;

    public BarangController(EMarketDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    [HttpGet]
    public IActionResult Barang()
    {
        var product = _dbcontext.Barangs.ToList();
        return Ok(product);
    }
    [HttpPost]
    public IActionResult InputBarang(RequestBarang req)
    {
        var barang = new Barang()
        {
            Kode = req.Kode,
            Nama = req.Nama,
            Harga = req.Harga,
            Description = req.Description,
            Stok = req.Stok,
            IdPenjual = req.IdPenjual
        };

        _dbcontext.Barangs.Add(barang);
        _dbcontext.SaveChanges();
        return Created("", barang);
    }

    [HttpGet("{id}")]
    public IActionResult DetailBarang(int id)
    {
        var product = _dbcontext.Barangs.FirstOrDefault(x => x.Id == id);
        return Ok(product);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBarang(int id, RequestBarang req)
    {
        var product = _dbcontext.Barangs.FirstOrDefault(x => x.Id == id);
        if (product == null)
        {
            return NotFound();
        };
        product.Kode = req.Kode;
        product.Nama = req.Nama;
        product.Harga = req.Harga;
        product.Description = req.Description;
        product.Stok = req.Stok;
        product.IdPenjual = req.IdPenjual;
        _dbcontext.SaveChanges();
        return Ok(product);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteBarang(int id)
    {
        var product = _dbcontext.Barangs.FirstOrDefault(x => x.Id == id);
        if (product == null)
        {
            return NotFound();
        };
        _dbcontext.Barangs.Remove(product);
        _dbcontext.SaveChanges();
        return Ok();
    }
}

