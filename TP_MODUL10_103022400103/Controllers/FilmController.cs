using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TP_MODUL10_103022400103;

[ApiController]
[Route("[controller]")]
public class FilmController : ControllerBase
{
    private static List<Film> films = new List<Film>
    {
        new Film { Id=1, Judul="Inception", Sutradara="Christopher Nolan", Tahun=2010, Genre="Sci-Fi", Rating=9.0 },
        new Film { Id=2, Judul="Interstellar", Sutradara="Christopher Nolan", Tahun=2014, Genre="Sci-Fi", Rating=8.7 },
        new Film { Id=3, Judul="Parasite", Sutradara="Bong Joon-ho", Tahun=2019, Genre="Thriller", Rating=8.6 }
    };

    [HttpGet]
    public ActionResult<List<Film>> GetAll()
    {
        return films;
    }

    [HttpGet("{id}")]
    public ActionResult<Film> GetById(int id)
    {
        if (id < 1)
            return NotFound("Index tidak ditemukan");

        return films[id-1];
    }

    [HttpPost]
    public ActionResult AddFilm([FromBody] Film film)
    {
        films.Add(film);
        return Ok("Film berhasil ditambahkan");
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteFilm(int id)
    {
        if (id < 1)
            return NotFound("Index tidak ditemukan");

        films.RemoveAt(id-1);
        return Ok("Film berhasil dihapus");
    }
}