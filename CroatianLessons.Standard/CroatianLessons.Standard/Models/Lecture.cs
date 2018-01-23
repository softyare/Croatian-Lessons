using System.Collections.Generic;

namespace CroatianLessons.Standard.Models
{
    public class Lecture
    {
        public string LectureId { get; set; }
        public string Title { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}