using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tpmodul10_103022330026.NewFolder;
using System.Collections.Generic;

namespace tpmodul10_103022330026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa {Nama  = "Raditya", Nim = "103022330026" },
            new Mahasiswa {Nama = "Daniyal", Nim = "1030223" },
            new Mahasiswa {Nama = "Admiral", Nim = "1030223" },
            new Mahasiswa {Nama = "Azka", Nim = "1030223" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> Get()
        {
            return mahasiswaList;
        }

        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> Get(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
            {
                return NotFound("Mahasiswa tidak ditemukan.");
            }
            return mahasiswaList[index];
        }

        [HttpPost]
        public ActionResult<IEnumerable<Mahasiswa>> Post([FromBody] Mahasiswa mahasiswaBaru)
        {
            mahasiswaList.Add(mahasiswaBaru);
            return mahasiswaList;
        }

        [HttpDelete("{index}")]
        public ActionResult<IEnumerable<Mahasiswa>> Delete(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
            {
                return NotFound("Mahasiswa tidak ditemukan.");
            }
            mahasiswaList.RemoveAt(index);
            return mahasiswaList;
        }
    }
}
