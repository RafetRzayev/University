using Microsoft.AspNetCore.Http;

namespace University.BLL.Dtos
{
    public class StudentCreateDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public byte Age { get; set; }

        //public IFormFile File { get; set; }
    }
}
