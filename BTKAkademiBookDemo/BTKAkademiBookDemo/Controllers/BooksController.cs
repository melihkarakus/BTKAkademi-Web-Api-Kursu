using BTKAkademiBookDemo.Data;
using BTKAkademiBookDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BTKAkademiBookDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            //books diye bir parametre tanımlandı. applicationcontext sınıfındaki verileri tanımlamak için o sınıf eklendi.
            //Books applicationcontextdeki Books tablosundaki verileri listelemek için ToList kullanıldı.
            var books = ApplicationContext.Books.ToList();
            return Ok(books);//Apide verilerin listelenmesi için 200 code gönderildi.
        }
        [HttpGet("GetOneBookID")]
        public IActionResult GetOneBookID(int id)
        {
            //book diye bir parametre tanımlandı. appcontextdeki Books Tablosundaki id FirstOrDefault ile seçildi.
            var book = ApplicationContext.Books.FirstOrDefault(x => x.ID == id);
            if (book == null) //book içindeki id eğer yanlış ise 
            {
                return NotFound("Girdiğiniz Değer Hatalıdır.");//hatayı göster
            }
            else //doğru ise 
            {
                return Ok(book); //Kitabı göster
            }
        }
        [HttpPost]
        public IActionResult CreateBooks(Book book)
        {
            try
            {
                if (book is null) //eğer book null ise 
                {
                    return BadRequest("Gönderilen değerler farklıdır."); //değer yanlış
                }
                ApplicationContext.Books.Add(book); //doğru ise değeri ekle
                return Ok(book);//değeri göster
            }
            catch (Exception ex)//ex ifadesi tanımlandı
            {
                return BadRequest(ex.Message); //hatayı gösterildi.
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            var entity = ApplicationContext.Books.Find(x => x.ID == id);
            if(entity is null)
            {
                return NotFound("Böyle bir tanım yoktur.");
            }
            else
            {
                ApplicationContext.Books.Remove(entity);
                book.ID = entity.ID;
                ApplicationContext.Books.Add(book);
                return Ok(book);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id) 
        {
            // books parametresine bir id atam işlemi yapıldı.
            var books = ApplicationContext.Books.FirstOrDefault(x => x.ID == id);
            
            if (books != null) //eğer kitap alanı boş ise silinemedi
            {
                ApplicationContext.Books.Remove(books);
                return Ok("Veri başarılı şekilde silindi.");
                
            }
            else
            {   //Kitap ıdsi bulundu ve başarılı ise kitap silinebilir.           
                return NotFound("Veri silinemedi");
            }
        }
        [HttpPatch]
        public IActionResult PartiallyUpdateBook(int id, JsonPatchDocument<Book> bookPatch)
        {
            var entity = ApplicationContext.Books.Find(x => x.ID == id);
            if(entity == null)
            {
                return NotFound("Bulunamadı");
            }
            else
            {
                bookPatch.ApplyTo(entity);
            }
            return NoContent();
        }
    }
}
